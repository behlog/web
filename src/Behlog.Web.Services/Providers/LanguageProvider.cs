namespace Behlog.Web.Services;

/// <inheritdoc />
public class LanguageProvider : ILanguageProvider
{
    private readonly IBehlogMediator _behlog;

    public LanguageProvider(IBehlogMediator behlog)
    {
        _behlog = behlog ?? throw new ArgumentNullException(nameof(behlog));
    }
    
    /// <inheritdoc />
    public async Task<SelectListViewModel> GetSelectListAsync(
        EntityStatus? status = null, CancellationToken cancellationToken = default)
    {
        var query = new QueryLanguages(status);
        var result = await _behlog.PublishAsync(query, cancellationToken).ConfigureAwait(false);

        return new SelectListViewModel(result.Select(
            _ => new SelectListItemViewModel(_.Title, _.Id.ToString()))
            );
    }
}