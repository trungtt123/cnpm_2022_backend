﻿namespace CNPM.Core.Utils
{
    public class Constant
    {
        public const string API_BASE = "api/v1";
        public const string INVALID_USER_CREDENTIALS = "INVALID_USER_CREDENTIALS";
        public const int DELETE = 1;
        public const int NOT_DELETE = 0;
        public const int ALIVE = 1;
        public const int DIE = 0;
        public const string VALID_TOKEN = "Token hợp lệ";
        public const string INVALID_TOKEN = "Token không hợp lệ";
        public const string DATA_UPDATED_BEFORE = "Dữ liệu bạn muốn cập nhật đã bị thay đổi bởi người khác";

        public const string USERNAME_NOT_EXIST = "Username không tồn tại";
        public const string INVALID_PASSWORD = "Mật khẩu không đúng";
        public const string LOGIN_SUCCESSFULLY = "Đăng nhập thành công";
        public const string LOGOUT_SUCCESSFULLY = "Đăng xuất thành công";

        public const string GET_USER_SUCCESSFULLY = "Lấy thông tin user thành công";

        public const string GET_LIST_PERMISSIONS_SUCCESSFULLY = "Lấy danh sách vai trò thành công";
        public const string GET_LIST_PERMISSIONS_FAILED = "Lấy danh sách vai trò thất bại";

        public const string DELETE_USER_SUCCESSFULLY = "Xóa user thành công";
        public const string DELETE_USER_FAILED = "Xóa user thất bại";

        public const string CREATE_USER_SUCCESSFULLY = "Tạo user thành công";
        public const string CREATE_USER_FAILED = "Tạo user thất bại";

        public const string UPDATE_USER_SUCCESSFULLY = "Cập nhật thông tin người dùng thành công";
        public const string UPDATE_USER_FAILED = "Cập nhật thông tin người dùng thất bại";

        public const string GET_USER_FAILED = "Lấy thông tin user thất bại";

        public const string GET_LIST_USERS_SUCCESSFULLY = "Lấy danh sách user thành công";
        public const string GET_LIST_USERS_FAILED = "Lấy danh sách user thất bại";

        public const string CHANGE_PASSWORD_SUCCESSFULLY = "Đổi mật khẩu thành công";
        public const string CHANGE_PASSWORD_FAILED = "Đổi mật khẩu thất bại";

        public const string SYSTEM_EMAIL_ADDRESS = "no-reply-project-3@outlook.com";
        public const string SYSTEM_EMAIL_PASSWORD = "project3";

        public const string GET_LIST_NHAN_KHAU_SUCCESSFULLY = "Lấy danh sách nhân khẩu thành công";
        public const string GET_LIST_NHAN_KHAU_ALIVE_SUCCESSFULLY = "Lấy danh sách nhân khẩu chưa đăng ký tạm vắng thành công";
        public const string GET_LIST_NHAN_KHAU_NOT_HAVE_HO_KHAU_SUCCESSFULLY = "Lấy danh sách nhân khẩu chưa có hộ khẩu thành công";
        public const string GET_LIST_NHAN_KHAU_FAILED = "Lấy danh sách nhân khẩu thất bại";

        public const string GET_LIST_KHOAN_THU_SUCCESSFULLY = "Lấy danh sách khoản thu thành công";
        public const string GET_LIST_KHOAN_THU_FAILED = "Lấy danh sách khoản thu thất bại";

        public const string GET_LIST_HO_KHAU_SUCCESSFULLY = "Lấy danh sách hộ khẩu thành công";
        public const string GET_LIST_HO_KHAU_FAILED = "Lấy danh sách hộ khẩu thất bại";

        public const string GET_LIST_TAM_TRU_SUCCESSFULLY = "Lấy danh sách tạm trú thành công";
        public const string GET_LIST_TAM_TRU_FAILED = "Lấy danh sách tạm trú thất bại";

        public const string GET_LIST_TAM_VANG_SUCCESSFULLY = "Lấy danh sách tạm vắng thành công";
        public const string GET_LIST_TAM_VANG_FAILED = "Lấy danh sách tạm vắng thất bại";

        public const string GET_NHAN_KHAU_SUCCESSFULLY = "Lấy thông tin nhân khẩu thành công";
        public const string GET_NHAN_KHAU_FAILED = "Lấy thông tin nhân khẩu thất bại";

        public const string GET_KHOAN_THU_SUCCESSFULLY = "Lấy thông tin khoản thu thành công";
        public const string GET_KHOAN_THU_FAILED = "Lấy thông tin khoản thu thất bại";

        public const string GET_KHOAN_THU_THEO_HO_SUCCESSFULLY = "Lấy thông tin khoản thu theo hộ thành công";
        public const string GET_KHOAN_THU_THEO_HO_FAILED = "Lấy thông tin khoản thu theo hộ thất bại";

        public const string GET_HO_KHAU_SUCCESSFULLY = "Lấy thông tin hộ khẩu thành công";
        public const string GET_HO_KHAU_FAILED = "Lấy thông tin hộ khẩu thất bại";

        public const string GET_TAM_TRU_SUCCESSFULLY = "Lấy thông tin tạm trú thành công";
        public const string GET_TAM_TRU_FAILED = "Lấy thông tin tạm trú thất bại";

        public const string GET_TAM_VANG_SUCCESSFULLY = "Lấy thông tin tạm vắng thành công";
        public const string GET_TAM_VANG_FAILED = "Lấy thông tin tạm vắng thất bại";

        public const string CREATE_NHAN_KHAU_SUCCESSFULLY = "Thêm mới nhân khẩu thành công";
        public const string CREATE_NHAN_KHAU_FAILED = "Thêm mới nhân khẩu thất bại";
        public const string REASON_CCCD_EXISTED = "Căn cước công dân đã tồn tại";

        public const string CREATE_KHOAN_THU_SUCCESSFULLY = "Thêm mới khoản thu thành công";
        public const string CREATE_KHOAN_THU_FAILED = "Thêm mới khoản thu thất bại";

        public const string CREATE_KHOAN_THU_THEO_HO_SUCCESSFULLY = "Thêm mới khoản thu theo hộ thành công";
        public const string CREATE_KHOAN_THU_THEO_HO_FAILED = "Thêm mới khoản thu theo hộ thất bại";

        public const string CREATE_HO_KHAU_SUCCESSFULLY = "Thêm mới hộ khẩu thành công";
        public const string CREATE_HO_KHAU_FAILED = "Thêm mới hộ khẩu thất bại";
        public const string REASON_MA_HO_KHAU_EXISTED = "Mã hộ khẩu đã tồn tại";

        public const string CREATE_TAM_TRU_SUCCESSFULLY = "Thêm mới tạm trú thành công";
        public const string CREATE_TAM_TRU_FAILED = "Thêm mới tạm trú thất bại";
        public const string REASON_CCCD_TAM_TRU_EXISTED = "Căn cước công dân này đã đăng ký tạm trú";

        public const string CREATE_TAM_VANG_SUCCESSFULLY = "Thêm mới tạm vắng thành công";
        public const string CREATE_TAM_VANG_FAILED = "Thêm mới tạm vắng thất bại";
        public const string REASON_NHAN_KHAU_TAM_VANG_EXISTED = "Nhân khẩu này đã đăng ký tạm vắng";

        public const string UPDATE_NHAN_KHAU_SUCCESSFULLY = "Cập nhật thông tin nhân khẩu thành công";
        public const string UPDATE_NHAN_KHAU_FAILED = "Cập nhật thông tin nhân khẩu thất bại";
        public const string MA_NHAN_KHAU_NOT_EXIST = "Mã nhân khẩu không tồn tại";
        public const string NHAN_KHAU_IS_DIED = "Nhân khẩu đã qua đời";

        public const string UPDATE_KHOAN_THU_SUCCESSFULLY = "Cập nhật thông tin khoản thu thành công";
        public const string UPDATE_KHOAN_THU_FAILED = "Cập nhật thông tin khoản thu thất bại";
        public const string MA_KHOAN_THU_NOT_EXIST = "Mã khoản thu không tồn tại";

        public const string UPDATE_TAM_TRU_SUCCESSFULLY = "Cập nhật thông tin tạm trú thành công";
        public const string UPDATE_TAM_TRU_FAILED = "Cập nhật thông tin tạm trú thất bại";
        public const string MA_TAM_TRU_NOT_EXIST = "Mã tạm trú không tồn tại";

        public const string UPDATE_TAM_VANG_SUCCESSFULLY = "Cập nhật thông tin tạm vắng thành công";
        public const string UPDATE_TAM_VANG_FAILED = "Cập nhật thông tin tạm vắng thất bại";
        public const string MA_TAM_VANG_NOT_EXIST = "Mã tạm vắng không tồn tại";

        public const string UPDATE_HO_KHAU_SUCCESSFULLY = "Cập nhật thông tin hộ khẩu thành công";
        public const string UPDATE_HO_KHAU_FAILED = "Cập nhật thông tin hộ khẩu thất bại";
        public const string MA_HO_KHAU_NOT_EXIST = "Mã hộ khẩu không tồn tại";

        public const string DELETE_NHAN_KHAU_SUCCESSFULLY = "Xóa thông tin nhân khẩu thành công";
        public const string DELETE_NHAN_KHAU_FAILED = "Xoá thông tin nhân khẩu thất bại";

        public const string DELETE_KHOAN_THU_SUCCESSFULLY = "Xóa thông tin khoản thu thành công";
        public const string DELETE_KHOAN_THU_FAILED = "Xoá thông tin khoản thu thất bại";

        public const string DELETE_HO_KHAU_SUCCESSFULLY = "Xóa thông tin hộ khẩu thành công";
        public const string DELETE_HO_KHAU_FAILED = "Xoá thông tin hộ khẩu thất bại";

        public const string DELETE_TAM_TRU_SUCCESSFULLY = "Xóa thông tin tạm trú thành công";
        public const string DELETE_TAM_TRU_FAILED = "Xoá thông tin tạm trú thất bại";

        public const string DELETE_TAM_VANG_SUCCESSFULLY = "Xóa thông tin tạm vắng thành công";
        public const string DELETE_TAM_VANG_FAILED = "Xoá thông tin tạm vắng thất bại";

        public const string THANH_TOAN_SUCCESSFULLY = "Thanh toán thành công";
        public const string THANH_TOAN_FAILED = "Thanh toán thất bại";

        public const string LOGOUT_FAILED = "Đăng xuất thất bại";
        public const string DEFAULT_PASSWORD = "123456";
        public const int RANDOM_DEFAULT_PASSWORD_LENGTH = 6;


        public const string Administrator = "1";
        public const string Manager = "2";
        public const string Stocker = "3";



        public const string CONNECTION_STRING = @"
                Data Source=localhost;
                Initial Catalog=CNPM;
                Integrated Security=True;
                Connect Timeout=30;
                Encrypt=False;
                TrustServerCertificate=False;
                ApplicationIntent=ReadWrite;
                MultiSubnetFailover=False";
    }
}
