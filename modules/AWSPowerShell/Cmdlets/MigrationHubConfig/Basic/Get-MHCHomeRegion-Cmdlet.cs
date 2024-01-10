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
using Amazon.MigrationHubConfig;
using Amazon.MigrationHubConfig.Model;

namespace Amazon.PowerShell.Cmdlets.MHC
{
    /// <summary>
    /// Returns the calling account’s home region, if configured. This API is used by other
    /// AWS services to determine the regional endpoint for calling AWS Application Discovery
    /// Service and Migration Hub. You must call <c>GetHomeRegion</c> at least once before
    /// you call any other AWS Application Discovery Service and AWS Migration Hub APIs, to
    /// obtain the account's Migration Hub home region.
    /// </summary>
    [Cmdlet("Get", "MHCHomeRegion")]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Migration Hub Config GetHomeRegion API operation.", Operation = new[] {"GetHomeRegion"}, SelectReturnType = typeof(Amazon.MigrationHubConfig.Model.GetHomeRegionResponse))]
    [AWSCmdletOutput("System.String or Amazon.MigrationHubConfig.Model.GetHomeRegionResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.MigrationHubConfig.Model.GetHomeRegionResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetMHCHomeRegionCmdlet : AmazonMigrationHubConfigClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'HomeRegion'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MigrationHubConfig.Model.GetHomeRegionResponse).
        /// Specifying the name of a property of type Amazon.MigrationHubConfig.Model.GetHomeRegionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "HomeRegion";
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
                context.Select = CreateSelectDelegate<Amazon.MigrationHubConfig.Model.GetHomeRegionResponse, GetMHCHomeRegionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            
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
            var request = new Amazon.MigrationHubConfig.Model.GetHomeRegionRequest();
            
            
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
        
        private Amazon.MigrationHubConfig.Model.GetHomeRegionResponse CallAWSServiceOperation(IAmazonMigrationHubConfig client, Amazon.MigrationHubConfig.Model.GetHomeRegionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Migration Hub Config", "GetHomeRegion");
            try
            {
                #if DESKTOP
                return client.GetHomeRegion(request);
                #elif CORECLR
                return client.GetHomeRegionAsync(request).GetAwaiter().GetResult();
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
            public System.Func<Amazon.MigrationHubConfig.Model.GetHomeRegionResponse, GetMHCHomeRegionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.HomeRegion;
        }
        
    }
}
