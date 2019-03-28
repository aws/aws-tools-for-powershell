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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Advertises an IPv4 address range that is provisioned for use with your AWS resources
    /// through bring your own IP addresses (BYOIP).
    /// 
    ///  
    /// <para>
    /// You can perform this operation at most once every 10 seconds, even if you specify
    /// different address ranges each time.
    /// </para><para>
    /// We recommend that you stop advertising the BYOIP CIDR from other locations when you
    /// advertise it from AWS. To minimize down time, you can configure your AWS resources
    /// to use an address from a BYOIP CIDR before it is advertised, and then simultaneously
    /// stop advertising it from the current location and start advertising it through AWS.
    /// </para><para>
    /// It can take a few minutes before traffic to the specified addresses starts routing
    /// to AWS because of BGP propagation delays.
    /// </para><para>
    /// To stop advertising the BYOIP CIDR, use <a>WithdrawByoipCidr</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Start", "EC2ByoipCidrAdvertisement", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.ByoipCidr")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud AdvertiseByoipCidr API operation.", Operation = new[] {"AdvertiseByoipCidr"})]
    [AWSCmdletOutput("Amazon.EC2.Model.ByoipCidr",
        "This cmdlet returns a ByoipCidr object.",
        "The service call response (type Amazon.EC2.Model.AdvertiseByoipCidrResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class StartEC2ByoipCidrAdvertisementCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter Cidr
        /// <summary>
        /// <para>
        /// <para>The IPv4 address range, in CIDR notation. This must be the exact range that you provisioned.
        /// You can't advertise only a portion of the provisioned range.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String Cidr { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("Cidr", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-EC2ByoipCidrAdvertisement (AdvertiseByoipCidr)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.Cidr = this.Cidr;
            
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
            var request = new Amazon.EC2.Model.AdvertiseByoipCidrRequest();
            
            if (cmdletContext.Cidr != null)
            {
                request.Cidr = cmdletContext.Cidr;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.ByoipCidr;
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
        
        private Amazon.EC2.Model.AdvertiseByoipCidrResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.AdvertiseByoipCidrRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud", "AdvertiseByoipCidr");
            try
            {
                #if DESKTOP
                return client.AdvertiseByoipCidr(request);
                #elif CORECLR
                return client.AdvertiseByoipCidrAsync(request).GetAwaiter().GetResult();
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
            public System.String Cidr { get; set; }
        }
        
    }
}
