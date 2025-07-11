using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WireGram.Abstractions;

namespace WireGram.Storage.Converters
{
    internal class EncryptedConverter(ICryptographyService service, ConverterMappingHints? mappingHints = null) : 
        ValueConverter<string, string>(t => service.Encrypt(t), t => service.Decrypt(t), mappingHints);
}
