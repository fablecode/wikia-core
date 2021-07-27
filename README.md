![alt text](https://fablecode.visualstudio.com/wikia-core/_apis/build/status/wikia-core%20CD "Visual studio team services build status") 

# Wikia-Core
Wikia is a C# .Net Standard 2.1 library that provides resource oriented interfaces and clients for the Wikia Api.

## How?
Every wiki has its API accessible through URL: {wikidomain}/api/v1/.

For example:

1. [http://www.wikia.com/api/v1/](http://www.wikia.com/api/v1/)
2. [http://yugioh.fandom.com/api/v1/](http://yugioh.fandom.com/api/v1/)
3. [http://naruto.fandom.com/api/v1/](http://naruto.fandom.com/api/v1/)
4. [http://elderscrolls.fandom.com/api/v1/](http://elderscrolls.fandom.com/api/v1/)

## NuGet
    PM> Install-Package wikia.core

## Quickstart

```csharp

// wiki domain
string domainUrl = "http://yugioh.fandom.com";

// Article endpoint
IWikiArticleList articles = new WikiArticleList(domainUrl);

// Get all Yugioh card tips ordered alphabetically
var result = articles.AlphabeticalList("Card Tips");
```

##### To get information about a specific article

```csharp
// Get articles by id
IWikiArticle article = new WikiArticle(domainUrl);

var articleId = 50

// Simple info
var articleSimpleResult = article.Simple(articleId);

// Detail info
var articleDetailsResult = article.Details(articleId);

```

## Endpoints

For a list of all endpoints, visit wiki api using {wikidomain}/api/v1/ format.

Example: For Yugioh Wiki Api endpoints, i'd use [http://yugioh.fandom.com/api/v1/](http://yugioh.wikia.com/api/v1/).

Notice the domain is "http://yugioh.fandom.com" and the suffix is "/api/v1/"

## License
This project is licensed under the MIT License - see the [LICENSE.md](LICENSE) file for details.
