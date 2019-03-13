/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// </summary>
    [Cmdlet("Get", "CFGAggregateResourceConfig")]
    [OutputType("Amazon.ConfigService.Model.ConfigurationItem")]
    [AWSCmdlet("Calls the AWS Config GetAggregateResourceConfig API operation.", Operation = new[] {"GetAggregateResourceConfig"})]
    [AWSCmdletOutput("Amazon.ConfigService.Model.ConfigurationItem",
        "This cmdlet returns a ConfigurationItem object.",
        "The service call response (type Amazon.ConfigService.Model.GetAggregateResourceConfigResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetCFGAggregateResourceConfigCmdlet : AmazonConfigServiceClientCmdlet, IExecutor
    {
        
        #region Parameter ConfigurationAggregatorName
        /// <summary>
        /// <para>
        /// <para>The name of the configuration aggregator.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ConfigurationAggregatorName { get; set; }
        #endregion
        
        #region Parameter ResourceIdentifier_ResourceId
        /// <summary>
        /// <para>
        /// <para>The ID of the AWS resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ResourceIdentifier_ResourceId { get; set; }
        #endregion
        
        #region Parameter ResourceIdentifier_ResourceName
        /// <summary>
        /// <para>
        /// <para>The name of the AWS resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ResourceIdentifier_ResourceName { get; set; }
        #endregion
        
        #region Parameter ResourceIdentifier_ResourceType
        /// <summary>
        /// <para>
        /// <para>The type of the AWS resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.ConfigService.ResourceType")]
        public Amazon.ConfigService.ResourceType ResourceIdentifier_ResourceType { get; set; }
        #endregion
        
        #region Parameter ResourceIdentifier_SourceAccountId
        /// <summary>
        /// <para>
        /// <para>The 12-digit account ID of the source account.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ResourceIdentifier_SourceAccountId { get; set; }
        #endregion
        
        #region Parameter ResourceIdentifier_SourceRegion
        /// <summary>
        /// <para>
        /// <para>The source region where data is aggregated.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ResourceIdentifier_SourceRegion { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.ConfigurationAggregatorName = this.ConfigurationAggregatorName;
            context.ResourceIdentifier_ResourceId = this.ResourceIdentifier_ResourceId;
            context.ResourceIdentifier_ResourceName = this.ResourceIdentifier_ResourceName;
            context.ResourceIdentifier_ResourceType = this.ResourceIdentifier_ResourceType;
            context.ResourceIdentifier_SourceAccountId = this.ResourceIdentifier_SourceAccountId;
            context.ResourceIdentifier_SourceRegion = this.ResourceIdentifier_SourceRegion;
            
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
            bool requestResourceIdentifierIsNull = true;
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
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.ConfigurationItem;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
        }
        
    }
}
