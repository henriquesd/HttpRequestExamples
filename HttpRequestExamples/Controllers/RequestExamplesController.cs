using AutoMapper;
using HttpRequestExamples.Dtos;
using HttpRequestExamples.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HttpRequestExamples.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RequestExamplesController : ControllerBase
    {
        private readonly IMapper _mapper;

        private readonly IHttpClientExample _httpClientExample;
        private readonly IHttpClientFactoryExample _httpClientFactoryExample;

        public RequestExamplesController(IMapper mapper,
            IHttpClientExample httpClientExample,
            IHttpClientFactoryExample httpClientFactoryExample)
        {
            _mapper = mapper;
            _httpClientExample = httpClientExample;
            _httpClientFactoryExample = httpClientFactoryExample;
        }

        [HttpGet("GetWithHttpClient")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetWithHttpClient()
        {
            try
            {
                var btcContent = await _httpClientExample.GetBtcContent();

                return Ok(_mapper.Map<BtcDto>(btcContent));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("GetWithIHttpClientFactory")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetWithWithIHttpClientFactory()
        {
            try
            {
                var btcContent = await _httpClientFactoryExample.GetBtcContent();

                return Ok(_mapper.Map<BtcDto>(btcContent));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("GetWithIHttpClientFactoryWithNamedClient")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetWithIHttpClientFactoryWithNamedClient()
        {
            try
            {
                var btcContent = await _httpClientFactoryExample.GetBtcContentWithNamedClient();

                return Ok(_mapper.Map<BtcDto>(btcContent));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [Obsolete]
        [HttpGet("GetWithHttpClientWithUsing")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetWithHttpClientWithUsing()
        {
            try
            {
                var btcContent = await _httpClientExample.GetBtcContentWithUsing();

                return Ok(_mapper.Map<BtcDto>(btcContent));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}