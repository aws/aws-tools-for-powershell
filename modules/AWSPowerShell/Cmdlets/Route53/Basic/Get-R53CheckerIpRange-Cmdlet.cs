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
using Amazon.Route53;
using Amazon.Route53.Model;

namespace Amazon.PowerShell.Cmdlets.R53
{
    /// <summary>
    /// Route 53 does not perform authorization for this API because it retrieves information
    /// that is already available to the public.
    /// 
    ///  <important><para><code>GetCheckerIpRanges</code> still works, but we recommend that you download ip-ranges.json,
    /// which includes IP address ranges for all Amazon Web Services services. For more information,
    /// see <a href="https://docs.aws.amazon.com/Route53/latest/DeveloperGuide/route-53-ip-addresses.html">IP
    /// Address Ranges of Amazon Route 53 Servers</a> in the <i>Amazon Route 53 Developer
    /// Guide</i>.
    /// </para></important>
    /// </summary>
    [Cmdlet("Get", "R53CheckerIpRange")]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Route 53 GetCheckerIpRanges API operation.", Operation = new[] {"GetCheckerIpRanges"}, SelectReturnType = typeof(Amazon.Route53.Model.GetCheckerIpRangesResponse), LegacyAlias="Get-R53CheckerIpRanges")]
    [AWSCmdletOutput("System.String or Amazon.Route53.Model.GetCheckerIpRangesResponse",
        "This cmdlet returns a collection of System.String objects.",
        "The service call response (type Amazon.Route53.Model.GetCheckerIpRangesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetR53CheckerIpRangeCmdlet : AmazonRoute53ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'CheckerIpRanges'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Route53.Model.GetCheckerIpRangesResponse).
        /// Specifying the name of a property of type Amazon.Route53.Model.GetCheckerIpRangesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "CheckerIpRanges";
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
                context.Select = CreateSelectDelegate<Amazon.Route53.Model.GetCheckerIpRangesResponse, GetR53CheckerIpRangeCmdlet>(Select) ??
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
            var request = new Amazon.Route53.Model.GetCheckerIpRangesRequest();
            
            
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
        
        private Amazon.Route53.Model.GetCheckerIpRangesResponse CallAWSServiceOperation(IAmazonRoute53 client, Amazon.Route53.Model.GetCheckerIpRangesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Route 53", "GetCheckerIpRanges");
            try
            {
                #if DESKTOP
                return client.GetCheckerIpRanges(request);
                #elif CORECLR
                return client.GetCheckerIpRangesAsync(request).GetAwaiter().GetResult();
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
            public System.Func<Amazon.Route53.Model.GetCheckerIpRangesResponse, GetR53CheckerIpRangeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.CheckerIpRanges;
        }
        
    }
}
