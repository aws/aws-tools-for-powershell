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
using Amazon.Lightsail;
using Amazon.Lightsail.Model;

namespace Amazon.PowerShell.Cmdlets.LS
{
    /// <summary>
    /// Returns the timestamp and status of the last cache reset of a specific Amazon Lightsail
    /// content delivery network (CDN) distribution.
    /// </summary>
    [Cmdlet("Get", "LSDistributionLatestCacheReset")]
    [OutputType("Amazon.Lightsail.Model.GetDistributionLatestCacheResetResponse")]
    [AWSCmdlet("Calls the Amazon Lightsail GetDistributionLatestCacheReset API operation.", Operation = new[] {"GetDistributionLatestCacheReset"}, SelectReturnType = typeof(Amazon.Lightsail.Model.GetDistributionLatestCacheResetResponse))]
    [AWSCmdletOutput("Amazon.Lightsail.Model.GetDistributionLatestCacheResetResponse",
        "This cmdlet returns an Amazon.Lightsail.Model.GetDistributionLatestCacheResetResponse object containing multiple properties."
    )]
    public partial class GetLSDistributionLatestCacheResetCmdlet : AmazonLightsailClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DistributionName
        /// <summary>
        /// <para>
        /// <para>The name of the distribution for which to return the timestamp of the last cache reset.</para><para>Use the <c>GetDistributions</c> action to get a list of distribution names that you
        /// can specify.</para><para>When omitted, the response includes the latest cache reset timestamp of all your distributions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String DistributionName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Lightsail.Model.GetDistributionLatestCacheResetResponse).
        /// Specifying the name of a property of type Amazon.Lightsail.Model.GetDistributionLatestCacheResetResponse will result in that property being returned.
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
                context.Select = CreateSelectDelegate<Amazon.Lightsail.Model.GetDistributionLatestCacheResetResponse, GetLSDistributionLatestCacheResetCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DistributionName = this.DistributionName;
            
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
            var request = new Amazon.Lightsail.Model.GetDistributionLatestCacheResetRequest();
            
            if (cmdletContext.DistributionName != null)
            {
                request.DistributionName = cmdletContext.DistributionName;
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
        
        private Amazon.Lightsail.Model.GetDistributionLatestCacheResetResponse CallAWSServiceOperation(IAmazonLightsail client, Amazon.Lightsail.Model.GetDistributionLatestCacheResetRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Lightsail", "GetDistributionLatestCacheReset");
            try
            {
                #if DESKTOP
                return client.GetDistributionLatestCacheReset(request);
                #elif CORECLR
                return client.GetDistributionLatestCacheResetAsync(request).GetAwaiter().GetResult();
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
            public System.String DistributionName { get; set; }
            public System.Func<Amazon.Lightsail.Model.GetDistributionLatestCacheResetResponse, GetLSDistributionLatestCacheResetCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
