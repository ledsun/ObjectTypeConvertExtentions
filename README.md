# ObjectTypeConvetExtentionsとは #

オブジェクト型から各種型への変換用拡張メソッドです。

# インストール #

NUgetを使って下さい。
IDはObjectTypeConvertExtentionsです。

# 使い方 #

## 簡単な使用例 ##

取得したい型名のメソッドで型を変換します。

    object str = "1";
    int ret = str.Int(); //1 as int

nullとDBNullは0に変換します。

    object str = null;
    int ret = str.Int(); //0 as int

nullのまま取得する場合は型名Nullのメソッドを使ってください。

    object str = null;
    int? ret = str.IntNull(); //null

## 対応している型 ##

* bool
* byte
* datetime
* decimal
* double
* int
* int16
* int64
* string
* uint
