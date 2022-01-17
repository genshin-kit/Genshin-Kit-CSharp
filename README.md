# GenshinKit-CSharp

A full-featured C# wrapper for Hoyolab/米游社 exposed apis, easily querying data of genshin players.

+ Please beaware that the GenshinKit is not a complete implementation of the Genshin Kit, and still in rapidly iterating.
+ Feel free to open an [issue](https://github.com/genshin-kit/Genshin-Kit-CSharp/issues) and [pull requests](https://github.com/genshin-kit/Genshin-Kit-CSharp/pulls), any effective contribution is welcome.
+ Since this project is an unofficial wrapper, this repository may be archived or deleted.

## About

This project is inspired and initially supported by [genshin-kit-node](https://github.com/genshin-kit/genshin-kit-node), could be considered as a fork in C# of it.

### Build with

+ [Jetbrains Rider](https://jetbrains.com/rider/)
+ [Flurl.Http](https://flurl.dev/)
+ [Json.NET](https://www.newtonsoft.com/json)
+ [AHpx.Extensions](https://www.github.com/SinoAHpx/AHpx.Extensions)

### Installation

+ Nuget package manager: `Install-Package GenshinKit-CSharp`
+ .NET CLI: `dotnet add package GenshinKit`
+ **Your IDE nuget package interface**

### Contact

+ Telegram: [AHpxEx](https://t.me/AHpxEx)
+ Email: [AHpx@yandex.com](mailto:AHpx@yandex.com)

## Usage

GenshinKit mostly uses the method-chain style, so some of examples below maybe incomplete and will be marked.

Here is the 2 types of genshin servers, cookies of corresponding server is univeral to all the inferior uids. For an example, a Chinese server cookie `"xxxx"` could be used both `1xxxxx` and `5xxxxxxx` uids.

+ Chinese servers include:
    + `gh_01`: uid starts with **1 or 2**
    + `qd_01`: uid starts with **5**
+ Overseas servers include:
    + `os_euro`: uid starts with **7**
    + `os_aisa`: uid starts with **8**
    + `os_cht(Server of Taiwan, Hong Kong and Macau)`: uid starts with **9**
    + `os_usa`: uid starts with **6**

### Configure cookie

The project has supported both `Chinese servers` and `Overseas servers`, and either of them needs a `Cookie` to access the api.

So here is how to confiure your `cookie`:

*(incomplete)*
```cs
//Add single cookie, pass into a string directly will be auto cast to GenshinCookie object for Chinese servers
"uid".WithGenshinCookie("<your cookie for Chinese servers>")

//Add single cookie via explicitly declare a GenshinCookie object, remark: the default value of second parameter is `Oversea`
"uid".WithGenshinCookie(new GenshinCookie("<your cookie for overseas servers>"))

//Add multi cookies
"awd".WithGenshinCookies(new []{new GenshinCookie("<cookie>"), "<cookie>", new GenshinCookie("<cookie>", GenshinServerType.Chinese)})
```

### Configure language(optional)

After you've confiured the cookies, you can make some further configuration. The summary of all the methods in GenshinKit is written in English, though GenshinKit supports multi-language white requesting data. If you don't specify your language, default language is English. 

Here is how you specify your language:

*(incomplete)*

```cs
//specify language as simplified Chinese
 "uid"
    .WithGenshinCookie("")
    .WithLanguage(GenshinLanguage.zh_cn)
```

As you can see, `GenshinLanguage` is an enum type, you can see and choose all the supported languages.


### Get data

For current version, GenshinKit supports two types of data: `Index` and `Abyss`.

+ `Index`: a general summarization of certain player suchlike "how many geoculus has collected".
+ `Abyss`: a detailed record of a player's perforamnce in the abyss sprial.

GenshinKit provide asynchronous methods only, which means you should declare `await` before calling the method. And all the code examples below could be considered as an full invocation of the method.

```cs
//Querying index data of `uid`, a Chinese player
await "uid"
    .WithGenshinCookie("")
    .GetGenshinIndexAsync();

//Querying index data of `uid`, an Overseas player
await "uid"
    .WithGenshinCookie(new GenshinCookie(""))
    .GetGenshinIndexAsync();

//Querying index data of `uid`, a Chinese player, with result in simplified Chinese
await "uid"
    .WithGenshinCookie("")
    .WithLanguage(GenshinLanguage.zh_cn)
    .GetGenshinIndexAsync();
```