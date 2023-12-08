from collections import deque
 
class Graph:
    def __init__(self, adjac_lis):
        self.adjac_lis = adjac_lis
 
    def get_neighbors(self, v):
        return self.adjac_lis[v]
 
    # Dưới đây là hàm heuristic có các giá trị bằng nhau cho tất cả các nút
    def h(self, n):
        H = {
            'A': 1,
            'B': 1,
            'C': 1,
            'D': 1
        }
 
        return H[n]
 
    def a_star_algorithm(self, start, stop):
        # open_lst là một danh sách các nút đã được thăm,
        # nhưng hàng xóm của chúng chưa được kiểm tra hoàn toàn.
        # Nó bắt đầu với nút bắt đầu

        # Và closed_lst là một danh sách các nút đã được thăm
        # và hàng xóm của chúng đã được kiểm tra hoàn toàn
        open_lst = set([start])
        closed_lst = set([])
 
        # Biến 'poo' chứa các khoảng cách hiện tại từ điểm bắt đầu tới tất cả các nút khác
        # Giá trị mặc định là dương vô cùng
        poo = {}
        poo[start] = 0
 
        # Biến 'par' chứa một ánh xạ liên kết của tất cả các nút kề
        par = {}
        par[start] = start
 
        while len(open_lst) > 0:
            n = None
 
            # Nó sẽ tìm một nút có giá trị nhỏ nhất của hàm f()
            for v in open_lst:
                if n == None or poo[v] + self.h(v) < poo[n] + self.h(n):
                    n = v;
 
            if n == None:
                print('Path does not exist!')
                return None
 
            # Nếu nút hiện tại là điểm dừng (stop), chúng ta bắt đầu lại từ điểm bắt đầu (start)
            if n == stop:
                reconst_path = []
 
                while par[n] != n:
                    reconst_path.append(n)
                    n = par[n]
 
                reconst_path.append(start)
 
                reconst_path.reverse()
 
                print('Path found: {}'.format(reconst_path))
                return reconst_path
 
            # Đối với tất cả các hàng xóm của nút hiện tại, thực hiện:"
            for (m, weight) in self.get_neighbors(n):
              # Nếu nút hiện tại không có trong cả open_lst và closed_lst,
              # thêm nó vào open_lst và ghi nhận n là nút cha của nó (par)
                if m not in open_lst and m not in closed_lst:
                    open_lst.add(m)
                    par[m] = n
                    poo[m] = poo[n] + weight
 
                # kiểm tra xem việc thăm nút n trước rồi tới nút m có nhanh hơn không
                # Nếu có cập nhật dữ liệu par và dữ liệu poo
                # Nếu nút đã có trong closed_lst, di chuyển nó vào open_lst
                else:
                    if poo[m] > poo[n] + weight:
                        poo[m] = poo[n] + weight
                        par[m] = n
 
                        if m in closed_lst:
                            closed_lst.remove(m)
                            open_lst.add(m)
 
            # Xóa n khỏi open_lst và thêm n vào closed_lst
            # Vì tất cả các hàng xóm của nút đã được kiểm tra
            open_lst.remove(n)
            closed_lst.add(n)
 
        print('Path does not exist!')
        return None
    
# Input
adjac_lis = {
    'A': [('B', 1), ('C', 3), ('D', 7)],
    'B': [('D', 5)],
    'C': [('D', 12)]
 }

graph1 = Graph(adjac_lis)
graph1.a_star_algorithm('A', 'D')