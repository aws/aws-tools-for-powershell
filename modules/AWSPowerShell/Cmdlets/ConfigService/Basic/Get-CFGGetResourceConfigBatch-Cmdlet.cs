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
using Amazon.ConfigService;
using Amazon.ConfigService.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CFG
{
    /// <summary>
    /// Returns the <c>BaseConfigurationItem</c> for one or more requested resources. The
    /// operation also returns a list of resources that are not processed in the current request.
    /// If there are no unprocessed resources, the operation returns an empty unprocessedResourceKeys
    /// list. 
    /// 
    ///  <note><ul><li><para>
    /// The API does not return results for deleted resources.
    /// </para></li><li><para>
    ///  The API does not return any tags for the requested resources. This information is
    /// filtered out of the supplementaryConfiguration section of the API response.
    /// </para></li></ul></note>
    /// </summary>
    [Cmdlet("Get", "CFGGetResourceConfigBatch")]
    [OutputType("Amazon.ConfigService.Model.BatchGetResourceConfigResponse")]
    [AWSCmdlet("Calls the AWS Config BatchGetResourceConfig API operation.", Operation = new[] {"BatchGetResourceConfig"}, SelectReturnType = typeof(Amazon.ConfigService.Model.BatchGetResourceConfigResponse))]
    [AWSCmdletOutput("Amazon.ConfigService.Model.BatchGetResourceConfigResponse",
        "This cmdlet returns an Amazon.ConfigService.Model.BatchGetResourceConfigResponse object containing multiple properties."
    )]
    public partial class GetCFGGetResourceConfigBatchCmdlet : AmazonConfigServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ResourceKey
        /// <summary>
        /// <para>
        /// <para>A list of resource keys to be processed with the current request. Each element in
        /// the list consists of the resource type and resource ID.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("ResourceKeys")]
        public Amazon.ConfigService.Model.ResourceKey[] ResourceKey { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ConfigService.Model.BatchGetResourceConfigResponse).
        /// Specifying the name of a property of type Amazon.ConfigService.Model.BatchGetResourceConfigResponse will result in that property being returned.
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
                context.Select = CreateSelectDelegate<Amazon.ConfigService.Model.BatchGetResourceConfigResponse, GetCFGGetResourceConfigBatchCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.ResourceKey != null)
            {
                context.ResourceKey = new List<Amazon.ConfigService.Model.ResourceKey>(this.ResourceKey);
            }
            #if MODULAR
            if (this.ResourceKey == null && ParameterWasBound(nameof(this.ResourceKey)))
            {
                WriteWarning("You are passing $null as a value for parameter ResourceKey which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ConfigService.Model.BatchGetResourceConfigRequest();
            
            if (cmdletContext.ResourceKey != null)
            {
                request.ResourceKeys = cmdletContext.ResourceKey;
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
        
        private Amazon.ConfigService.Model.BatchGetResourceConfigResponse CallAWSServiceOperation(IAmazonConfigService client, Amazon.ConfigService.Model.BatchGetResourceConfigRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Config", "BatchGetResourceConfig");
            try
            {
                return client.BatchGetResourceConfigAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.ConfigService.Model.ResourceKey> ResourceKey { get; set; }
            public System.Func<Amazon.ConfigService.Model.BatchGetResourceConfigResponse, GetCFGGetResourceConfigBatchCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
