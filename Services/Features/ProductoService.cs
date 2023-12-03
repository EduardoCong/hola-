using TostiElotes.Domain.Entities;
using TostiElotes.Infrastructure.Repositories;

namespace TostiElotes.Services.Features
{
    public class ProductoService
    {

        private readonly ProductoRepository _clienteRepository;

        public ProductoService(ProductoRepository clienteRepository)
        {
            this._clienteRepository = clienteRepository;
        }

        public async Task<IEnumerable<Producto>> GetAll()
        {
            return await _clienteRepository.GetAll();
        }

        public async Task<Producto> GetById(int id)
        {
            return await _clienteRepository.GetById(id);
        }

        public async Task<byte[]> LeerImagenComoBytesAsync(string imagen)
        {
            try
            {
                Uri? uriResult;
                bool isUrl = Uri.TryCreate(imagen, UriKind.Absolute, out uriResult) && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);

                if (isUrl)
                {
                    // Descargar la imagen desde la URL
                    using (HttpClient client = new HttpClient())
                    {
                        byte[] imagenEnBytes = await client.GetByteArrayAsync(imagen);
                        return imagenEnBytes;
                    }
                }
                else
                {
                    // Es una ruta local, leer la imagen desde el archivo
                    using (FileStream fileStream = new FileStream(imagen, FileMode.Open, FileAccess.Read))
                    {
                        using (MemoryStream memoryStream = new MemoryStream())
                        {
                            await fileStream.CopyToAsync(memoryStream);
                            return memoryStream.ToArray();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar la excepción (por ejemplo, registrarla o lanzarla nuevamente)
                throw new Exception($"Error al leer la imagen: {ex.Message}", ex);
            }
        }



        public async Task Add(Producto cliente)
        {
            await _clienteRepository.Add(cliente);
        }

        public async Task Update(Producto clienteToUpdate)
        {
            var cliente = await GetById(clienteToUpdate.Id);

            if (cliente.Id >= 0)
            {
                await _clienteRepository.Update(clienteToUpdate);
            }
        }

        public async Task Delete(int id)
        {
            var cliente = await GetById(id);
            if (cliente.Id >= 0)
            {
                await _clienteRepository.Delete(id);
            }
        }
    }
}