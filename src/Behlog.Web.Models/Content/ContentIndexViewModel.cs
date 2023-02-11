namespace Behlog.Web.Models;

public class ContentIndexViewModel
{
	public ContentIndexViewModel() { }

	public QueryResult<ContentResult> Contents { get; set; }

	public ContentTypeResult ContentType { get; set; }

	public IEnumerable<ContentCategoryResult> Categories { get; set; }

	public IEnumerable<ContentTagResult> Tags { get; set; }

	public static ContentIndexViewModel New(ContentTypeResult contentType) {
		var model = new ContentIndexViewModel();
		model.ContentType = contentType;
		return model;
	}

	public ContentIndexViewModel WithContents(QueryResult<ContentResult> contents) {
		Contents = contents;
		return this;
	}

	public ContentIndexViewModel WithCategories(IEnumerable<ContentCategoryResult> categories) {
		Categories = categories;
		return this;
	}

	public ContentIndexViewModel WithTags(IEnumerable<ContentTagResult> tags) {
		Tags = tags;
		return this;
	}
}