/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.CloudFront;
using Amazon.CloudFront.Model;

namespace Amazon.PowerShell.Cmdlets.CF
{
    /// <summary>
    /// Delete a streaming distribution. To delete an RTMP distribution using the CloudFront
    /// API, perform the following steps.
    /// 
    ///  
    /// <para><b>To delete an RTMP distribution using the CloudFront API</b>:
    /// </para><ol><li><para>
    /// Disable the RTMP distribution.
    /// </para></li><li><para>
    /// Submit a <code>GET Streaming Distribution Config</code> request to get the current
    /// configuration and the <code>Etag</code> header for the distribution. 
    /// </para></li><li><para>
    /// Update the XML document that was returned in the response to your <code>GET Streaming
    /// Distribution Config</code> request to change the value of <code>Enabled</code> to
    /// <code>false</code>.
    /// </para></li><li><para>
    /// Submit a <code>PUT Streaming Distribution Config</code> request to update the configuration
    /// for your distribution. In the request body, include the XML document that you updated
    /// in Step 3. Then set the value of the HTTP <code>If-Match</code> header to the value
    /// of the <code>ETag</code> header that CloudFront returned when you submitted the <code>GET
    /// Streaming Distribution Config</code> request in Step 2.
    /// </para></li><li><para>
    /// Review the response to the <code>PUT Streaming Distribution Config</code> request
    /// to confirm that the distribution was successfully disabled.
    /// </para></li><li><para>
    /// Submit a <code>GET Streaming Distribution Config</code> request to confirm that your
    /// changes have propagated. When propagation is complete, the value of <code>Status</code>
    /// is <code>Deployed</code>.
    /// </para></li><li><para>
    /// Submit a <code>DELETE Streaming Distribution</code> request. Set the value of the
    /// HTTP <code>If-Match</code> header to the value of the <code>ETag</code> header that
    /// CloudFront returned when you submitted the <code>GET Streaming Distribution Config</code>
    /// request in Step 2.
    /// </para></li><li><para>
    /// Review the response to your <code>DELETE Streaming Distribution</code> request to
    /// confirm that the distribution was successfully deleted.
    /// </para></li></ol><para>
    /// For information about deleting a distribution using the CloudFront console, see <a href="http://docs.aws.amazon.com/AmazonCloudFront/latest/DeveloperGuide/HowToDeleteDistribution.html">Deleting
    /// a Distribution</a> in the <i>Amazon CloudFront Developer Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Remove", "CFStreamingDistribution", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Invokes the DeleteStreamingDistribution operation against Amazon CloudFront.", Operation = new[] {"DeleteStreamingDistribution"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the Id parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.CloudFront.Model.DeleteStreamingDistributionResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RemoveCFStreamingDistributionCmdlet : AmazonCloudFrontClientCmdlet, IExecutor
    {
        
        #region Parameter Id
        /// <summary>
        /// <para>
        /// <para>The distribution ID. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String Id { get; set; }
        #endregion
        
        #region Parameter IfMatch
        /// <summary>
        /// <para>
        /// <para>The value of the <code>ETag</code> header that you received when you disabled the
        /// streaming distribution. For example: <code>E2QWRUHAPOMQZL</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        public System.String IfMatch { get; set; }
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Returns the value passed to the Id parameter.
        /// By default, this cmdlet does not generate any output.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter PassThru { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("Id", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-CFStreamingDistribution (DeleteStreamingDistribution)"))
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
            
            context.Id = this.Id;
            context.IfMatch = this.IfMatch;
            
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
            var request = new Amazon.CloudFront.Model.DeleteStreamingDistributionRequest();
            
            if (cmdletContext.Id != null)
            {
                request.Id = cmdletContext.Id;
            }
            if (cmdletContext.IfMatch != null)
            {
                request.IfMatch = cmdletContext.IfMatch;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = null;
                if (this.PassThru.IsPresent)
                    pipelineOutput = this.Id;
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
        
        private Amazon.CloudFront.Model.DeleteStreamingDistributionResponse CallAWSServiceOperation(IAmazonCloudFront client, Amazon.CloudFront.Model.DeleteStreamingDistributionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudFront", "DeleteStreamingDistribution");
            #if DESKTOP
            return client.DeleteStreamingDistribution(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.DeleteStreamingDistributionAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String Id { get; set; }
            public System.String IfMatch { get; set; }
        }
        
    }
}
