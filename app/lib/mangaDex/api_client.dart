import 'package:dio/dio.dart';

class ApiClient {
  final Dio dio = Dio();

  Future<Response> Login() async {
    try {} on DioError catch (e) {
      //returns the error object if there is any.
      return e.response!.data;
    }
  }

  Future<Response> Register() async {}
}
