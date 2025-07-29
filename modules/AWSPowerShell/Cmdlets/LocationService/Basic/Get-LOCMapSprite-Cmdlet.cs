/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
 *  Licensed under the Apache License, Version 2.0 (the "License"). You may not use
 *  this file except in compliance with the License. A copy of the License is located at
 *
 *  http://aws.amazon.com/apache2.0
 *
 *  or in the "license" file accompanying this file.
 *  This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR
 *  CONDITIONS OF ANY KIND, either express or implied. See the License for the
 *  specific language governing permissions and limitations under the License.
 * *****************************************************************************
 *
 *  AWS Tools for Windows (TM) PowerShell (TM)
 *
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using Amazon.PowerShell.Common;
using Amazon.Runtime;
using System.Threading;
using Amazon.LocationService;
using Amazon.LocationService.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.LOC
{
    /// <summary>
    /// Retrieves the sprite sheet corresponding to a map resource. The sprite sheet is a
    /// PNG image paired with a JSON document describing the offsets of individual icons that
    /// will be displayed on a rendered map.
    /// </summary>
    [Cmdlet("Get", "LOCMapSprite")]
    [OutputType("Amazon.LocationService.Model.GetMapSpritesResponse")]
    [AWSCmdlet("Calls the Amazon Location Service GetMapSprites API operation.", Operation = new[] {"GetMapSprites"}, SelectReturnType = typeof(Amazon.LocationService.Model.GetMapSpritesResponse))]
    [AWSCmdletOutput("Amazon.LocationService.Model.GetMapSpritesResponse",
        "This cmdlet returns an Amazon.LocationService.Model.GetMapSpritesResponse object containing multiple properties."
    )]
    public partial class GetLOCMapSpriteCmdlet : AmazonLocationServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter FileName
        /// <summary>
        /// <para>
        /// <para>The name of the sprite ﬁle. Use the following ﬁle names for the sprite sheet:</para><ul><li><para><c>sprites.png</c></para></li><li><para><c>sprites@2x.png</c> for high pixel density displays</para></li></ul><para>For the JSON document containing image offsets. Use the following ﬁle names:</para><ul><li><para><c>sprites.json</c></para></li><li><para><c>sprites@2x.json</c> for high pixel density displays</para></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String FileName { get; set; }
        #endregion
        
        #region Parameter Key
        /// <summary>
        /// <para>
        /// <para>The optional <a href="https://docs.aws.amazon.com/location/previous/developerguide/using-apikeys.html">API
        /// key</a> to authorize the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Key { get; set; }
        #endregion
        
        #region Parameter MapName
        /// <summary>
        /// <para>
        /// <para>The map resource associated with the sprite ﬁle.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String MapName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LocationService.Model.GetMapSpritesResponse).
        /// Specifying the name of a property of type Amazon.LocationService.Model.GetMapSpritesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.LocationService.Model.GetMapSpritesResponse, GetLOCMapSpriteCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.FileName = this.FileName;
            #if MODULAR
            if (this.FileName == null && ParameterWasBound(nameof(this.FileName)))
            {
                WriteWarning("You are passing $null as a value for parameter FileName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Key = this.Key;
            context.MapName = this.MapName;
            #if MODULAR
            if (this.MapName == null && ParameterWasBound(nameof(this.MapName)))
            {
                WriteWarning("You are passing $null as a value for parameter MapName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.LocationService.Model.GetMapSpritesRequest();
            
            if (cmdletContext.FileName != null)
            {
                request.FileName = cmdletContext.FileName;
            }
            if (cmdletContext.Key != null)
            {
                request.Key = cmdletContext.Key;
            }
            if (cmdletContext.MapName != null)
            {
                request.MapName = cmdletContext.MapName;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                object pipelineOutput = null;
                pipelineOutput = cmdletContext.Select(response, this);
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response
                };
            }
            catch (Exception e)
            {
                output = new CmdletOutput { ErrorResponse = e };
            }
            
            return output;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.LocationService.Model.GetMapSpritesResponse CallAWSServiceOperation(IAmazonLocationService client, Amazon.LocationService.Model.GetMapSpritesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Location Service", "GetMapSprites");
            try
            {
                return client.GetMapSpritesAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
            }
            catch (AmazonServiceException exc)
            {
                var webException = exc.InnerException as System.Net.WebException;
                if (webException != null)
                {
                    throw new Exception(Utils.Common.FormatNameResolutionFailureMessage(client.Config, webException.Message), webException);
                }
                throw;
            }
        }
        
        #endregion
        
        internal partial class CmdletContext : ExecutorContext
        {
            public System.String FileName { get; set; }
            public System.String Key { get; set; }
            public System.String MapName { get; set; }
            public System.Func<Amazon.LocationService.Model.GetMapSpritesResponse, GetLOCMapSpriteCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
