/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.ConfigService;
using Amazon.ConfigService.Model;

namespace Amazon.PowerShell.Cmdlets.CFG
{
    /// <summary>
    /// Returns the current configuration items for resources that are present in your Config
    /// aggregator. The operation also returns a list of resources that are not processed
    /// in the current request. If there are no unprocessed resources, the operation returns
    /// an empty <code>unprocessedResourceIdentifiers</code> list. 
    /// 
    ///  <note><ul><li><para>
    /// The API does not return results for deleted resources.
    /// </para></li><li><para>
    ///  The API does not return tags and relationships.
    /// </para></li></ul></note>
    /// </summary>
    [Cmdlet("Get", "CFGAggregateResourceConfigBatch")]
    [OutputType("Amazon.ConfigService.Model.BatchGetAggregateResourceConfigResponse")]
    [AWSCmdlet("Calls the AWS Config BatchGetAggregateResourceConfig API operation.", Operation = new[] {"BatchGetAggregateResourceConfig"}, SelectReturnType = typeof(Amazon.ConfigService.Model.BatchGetAggregateResourceConfigResponse))]
    [AWSCmdletOutput("Amazon.ConfigService.Model.BatchGetAggregateResourceConfigResponse",
        "This cmdlet returns an Amazon.ConfigService.Model.BatchGetAggregateResourceConfigResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetCFGAggregateResourceConfigBatchCmdlet : AmazonConfigServiceClientCmdlet, IExecutor
    {
        
        #region Parameter ConfigurationAggregatorName
        /// <summary>
        /// <para>
        /// <para>The name of the configuration aggregator.</para>
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
        public System.String ConfigurationAggregatorName { get; set; }
        #endregion
        
        #region Parameter ResourceIdentifier
        /// <summary>
        /// <para>
        /// <para>A list of aggregate ResourceIdentifiers objects. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("ResourceIdentifiers")]
        public Amazon.ConfigService.Model.AggregateResourceIdentifier[] ResourceIdentifier { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ConfigService.Model.BatchGetAggregateResourceConfigResponse).
        /// Specifying the name of a property of type Amazon.ConfigService.Model.BatchGetAggregateResourceConfigResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ConfigService.Model.BatchGetAggregateResourceConfigResponse, GetCFGAggregateResourceConfigBatchCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ConfigurationAggregatorName = this.ConfigurationAggregatorName;
            #if MODULAR
            if (this.ConfigurationAggregatorName == null && ParameterWasBound(nameof(this.ConfigurationAggregatorName)))
            {
                WriteWarning("You are passing $null as a value for parameter ConfigurationAggregatorName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.ResourceIdentifier != null)
            {
                context.ResourceIdentifier = new List<Amazon.ConfigService.Model.AggregateResourceIdentifier>(this.ResourceIdentifier);
            }
            #if MODULAR
            if (this.ResourceIdentifier == null && ParameterWasBound(nameof(this.ResourceIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter ResourceIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ConfigService.Model.BatchGetAggregateResourceConfigRequest();
            
            if (cmdletContext.ConfigurationAggregatorName != null)
            {
                request.ConfigurationAggregatorName = cmdletContext.ConfigurationAggregatorName;
            }
            if (cmdletContext.ResourceIdentifier != null)
            {
                request.ResourceIdentifiers = cmdletContext.ResourceIdentifier;
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
        
        private Amazon.ConfigService.Model.BatchGetAggregateResourceConfigResponse CallAWSServiceOperation(IAmazonConfigService client, Amazon.ConfigService.Model.BatchGetAggregateResourceConfigRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Config", "BatchGetAggregateResourceConfig");
            try
            {
                #if DESKTOP
                return client.BatchGetAggregateResourceConfig(request);
                #elif CORECLR
                return client.BatchGetAggregateResourceConfigAsync(request).GetAwaiter().GetResult();
                #else
                        #error "Unknown build edition"
                #endif
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
            public System.String ConfigurationAggregatorName { get; set; }
            public List<Amazon.ConfigService.Model.AggregateResourceIdentifier> ResourceIdentifier { get; set; }
            public System.Func<Amazon.ConfigService.Model.BatchGetAggregateResourceConfigResponse, GetCFGAggregateResourceConfigBatchCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
