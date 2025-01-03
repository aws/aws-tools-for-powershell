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
    /// Returns configuration item that is aggregated for your specific resource in a specific
    /// source account and region.
    /// 
    ///  <note><para>
    /// The API does not return results for deleted resources.
    /// </para></note>
    /// </summary>
    [Cmdlet("Get", "CFGAggregateResourceConfig")]
    [OutputType("Amazon.ConfigService.Model.ConfigurationItem")]
    [AWSCmdlet("Calls the AWS Config GetAggregateResourceConfig API operation.", Operation = new[] {"GetAggregateResourceConfig"}, SelectReturnType = typeof(Amazon.ConfigService.Model.GetAggregateResourceConfigResponse))]
    [AWSCmdletOutput("Amazon.ConfigService.Model.ConfigurationItem or Amazon.ConfigService.Model.GetAggregateResourceConfigResponse",
        "This cmdlet returns an Amazon.ConfigService.Model.ConfigurationItem object.",
        "The service call response (type Amazon.ConfigService.Model.GetAggregateResourceConfigResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetCFGAggregateResourceConfigCmdlet : AmazonConfigServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
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
        
        #region Parameter ResourceIdentifier_ResourceId
        /// <summary>
        /// <para>
        /// <para>The ID of the Amazon Web Services resource.</para>
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
        public System.String ResourceIdentifier_ResourceId { get; set; }
        #endregion
        
        #region Parameter ResourceIdentifier_ResourceName
        /// <summary>
        /// <para>
        /// <para>The name of the Amazon Web Services resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ResourceIdentifier_ResourceName { get; set; }
        #endregion
        
        #region Parameter ResourceIdentifier_ResourceType
        /// <summary>
        /// <para>
        /// <para>The type of the Amazon Web Services resource.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.ConfigService.ResourceType")]
        public Amazon.ConfigService.ResourceType ResourceIdentifier_ResourceType { get; set; }
        #endregion
        
        #region Parameter ResourceIdentifier_SourceAccountId
        /// <summary>
        /// <para>
        /// <para>The 12-digit account ID of the source account.</para>
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
        public System.String ResourceIdentifier_SourceAccountId { get; set; }
        #endregion
        
        #region Parameter ResourceIdentifier_SourceRegion
        /// <summary>
        /// <para>
        /// <para>The source region where data is aggregated.</para>
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
        public System.String ResourceIdentifier_SourceRegion { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ConfigurationItem'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ConfigService.Model.GetAggregateResourceConfigResponse).
        /// Specifying the name of a property of type Amazon.ConfigService.Model.GetAggregateResourceConfigResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ConfigurationItem";
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
                context.Select = CreateSelectDelegate<Amazon.ConfigService.Model.GetAggregateResourceConfigResponse, GetCFGAggregateResourceConfigCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ConfigurationAggregatorName = this.ConfigurationAggregatorName;
            #if MODULAR
            if (this.ConfigurationAggregatorName == null && ParameterWasBound(nameof(this.ConfigurationAggregatorName)))
            {
                WriteWarning("You are passing $null as a value for parameter ConfigurationAggregatorName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ResourceIdentifier_ResourceId = this.ResourceIdentifier_ResourceId;
            #if MODULAR
            if (this.ResourceIdentifier_ResourceId == null && ParameterWasBound(nameof(this.ResourceIdentifier_ResourceId)))
            {
                WriteWarning("You are passing $null as a value for parameter ResourceIdentifier_ResourceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ResourceIdentifier_ResourceName = this.ResourceIdentifier_ResourceName;
            context.ResourceIdentifier_ResourceType = this.ResourceIdentifier_ResourceType;
            #if MODULAR
            if (this.ResourceIdentifier_ResourceType == null && ParameterWasBound(nameof(this.ResourceIdentifier_ResourceType)))
            {
                WriteWarning("You are passing $null as a value for parameter ResourceIdentifier_ResourceType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ResourceIdentifier_SourceAccountId = this.ResourceIdentifier_SourceAccountId;
            #if MODULAR
            if (this.ResourceIdentifier_SourceAccountId == null && ParameterWasBound(nameof(this.ResourceIdentifier_SourceAccountId)))
            {
                WriteWarning("You are passing $null as a value for parameter ResourceIdentifier_SourceAccountId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ResourceIdentifier_SourceRegion = this.ResourceIdentifier_SourceRegion;
            #if MODULAR
            if (this.ResourceIdentifier_SourceRegion == null && ParameterWasBound(nameof(this.ResourceIdentifier_SourceRegion)))
            {
                WriteWarning("You are passing $null as a value for parameter ResourceIdentifier_SourceRegion which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ConfigService.Model.GetAggregateResourceConfigRequest();
            
            if (cmdletContext.ConfigurationAggregatorName != null)
            {
                request.ConfigurationAggregatorName = cmdletContext.ConfigurationAggregatorName;
            }
            
             // populate ResourceIdentifier
            var requestResourceIdentifierIsNull = true;
            request.ResourceIdentifier = new Amazon.ConfigService.Model.AggregateResourceIdentifier();
            System.String requestResourceIdentifier_resourceIdentifier_ResourceId = null;
            if (cmdletContext.ResourceIdentifier_ResourceId != null)
            {
                requestResourceIdentifier_resourceIdentifier_ResourceId = cmdletContext.ResourceIdentifier_ResourceId;
            }
            if (requestResourceIdentifier_resourceIdentifier_ResourceId != null)
            {
                request.ResourceIdentifier.ResourceId = requestResourceIdentifier_resourceIdentifier_ResourceId;
                requestResourceIdentifierIsNull = false;
            }
            System.String requestResourceIdentifier_resourceIdentifier_ResourceName = null;
            if (cmdletContext.ResourceIdentifier_ResourceName != null)
            {
                requestResourceIdentifier_resourceIdentifier_ResourceName = cmdletContext.ResourceIdentifier_ResourceName;
            }
            if (requestResourceIdentifier_resourceIdentifier_ResourceName != null)
            {
                request.ResourceIdentifier.ResourceName = requestResourceIdentifier_resourceIdentifier_ResourceName;
                requestResourceIdentifierIsNull = false;
            }
            Amazon.ConfigService.ResourceType requestResourceIdentifier_resourceIdentifier_ResourceType = null;
            if (cmdletContext.ResourceIdentifier_ResourceType != null)
            {
                requestResourceIdentifier_resourceIdentifier_ResourceType = cmdletContext.ResourceIdentifier_ResourceType;
            }
            if (requestResourceIdentifier_resourceIdentifier_ResourceType != null)
            {
                request.ResourceIdentifier.ResourceType = requestResourceIdentifier_resourceIdentifier_ResourceType;
                requestResourceIdentifierIsNull = false;
            }
            System.String requestResourceIdentifier_resourceIdentifier_SourceAccountId = null;
            if (cmdletContext.ResourceIdentifier_SourceAccountId != null)
            {
                requestResourceIdentifier_resourceIdentifier_SourceAccountId = cmdletContext.ResourceIdentifier_SourceAccountId;
            }
            if (requestResourceIdentifier_resourceIdentifier_SourceAccountId != null)
            {
                request.ResourceIdentifier.SourceAccountId = requestResourceIdentifier_resourceIdentifier_SourceAccountId;
                requestResourceIdentifierIsNull = false;
            }
            System.String requestResourceIdentifier_resourceIdentifier_SourceRegion = null;
            if (cmdletContext.ResourceIdentifier_SourceRegion != null)
            {
                requestResourceIdentifier_resourceIdentifier_SourceRegion = cmdletContext.ResourceIdentifier_SourceRegion;
            }
            if (requestResourceIdentifier_resourceIdentifier_SourceRegion != null)
            {
                request.ResourceIdentifier.SourceRegion = requestResourceIdentifier_resourceIdentifier_SourceRegion;
                requestResourceIdentifierIsNull = false;
            }
             // determine if request.ResourceIdentifier should be set to null
            if (requestResourceIdentifierIsNull)
            {
                request.ResourceIdentifier = null;
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
        
        private Amazon.ConfigService.Model.GetAggregateResourceConfigResponse CallAWSServiceOperation(IAmazonConfigService client, Amazon.ConfigService.Model.GetAggregateResourceConfigRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Config", "GetAggregateResourceConfig");
            try
            {
                #if DESKTOP
                return client.GetAggregateResourceConfig(request);
                #elif CORECLR
                return client.GetAggregateResourceConfigAsync(request).GetAwaiter().GetResult();
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
            public System.String ResourceIdentifier_ResourceId { get; set; }
            public System.String ResourceIdentifier_ResourceName { get; set; }
            public Amazon.ConfigService.ResourceType ResourceIdentifier_ResourceType { get; set; }
            public System.String ResourceIdentifier_SourceAccountId { get; set; }
            public System.String ResourceIdentifier_SourceRegion { get; set; }
            public System.Func<Amazon.ConfigService.Model.GetAggregateResourceConfigResponse, GetCFGAggregateResourceConfigCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ConfigurationItem;
        }
        
    }
}
