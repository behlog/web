namespace Behlog.Web.Models;

public class ContentIndexViewModel
{
	public ContentIndexViewModel() { }

	public string LangCode { get; set; }

	public string? LangTitle { get; set; }

	public Guid LangId { get; set; }

	public QueryResult<ContentResult> Contents { get; set; }

	public ContentTypeResult ContentType { get; set; }

	public IEnumerable<ContentCategoryResult> Categories { get; set; }

	public IEnumerable<TagResult> Tags { get; set; }

	public static ContentIndexViewModel New(Guid langId, string langCode, string? langTitle) {
		var model = new ContentIndexViewModel {
			LangId = langId,
			LangCode = langCode,
			LangTitle = langTitle
		};

		return model;
	}

	public ContentIndexViewModel WithContentType(ContentTypeResult contentType) {
		ContentType = contentType;
		return this;
	}

	public ContentIndexViewModel WithContents(QueryResult<ContentResult> contents) {
		Contents = contents;
		return this;
	}

	public ContentIndexViewModel WithCategories(IEnumerable<ContentCategoryResult> categories) {
		Categories = categories;
		return this;
	}

	public ContentIndexViewModel WithTags(IEnumerable<TagResult> tags) {
		Tags = tags;
		return this;
	}
}