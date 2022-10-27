import 'package:dio/dio.dart';

class ApiClient {
  final Dio _dio = Dio();
  final apiUrl = "https://api.mangadex.org";

  Future<Response> Login(String username, String password) async {
    try {
      Response response = await _dio.post("$apiUrl/auth/login",
          data: {"username": username, "password": password});

      return response.data;
    } on DioError catch (e) {
      //returns the error object if there is any.
      return e.response!.data;
    }
  }

  Future<Response> Register() async {}
  Future<Response> Logout() async {}
  Future<Response> Refresh() async {}
}
