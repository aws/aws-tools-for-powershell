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
using Amazon.Macie;
using Amazon.Macie.Model;

namespace Amazon.PowerShell.Cmdlets.MAC
{
    /// <summary>
    /// Removes specified S3 resources from being monitored by Amazon Macie. If memberAccountId
    /// isn't specified, the action removes specified S3 resources from Macie for the current
    /// master account. If memberAccountId is specified, the action removes specified S3 resources
    /// from Macie for the specified member account.
    /// </summary>
    [Cmdlet("Remove", "MACS3Resource", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("Amazon.Macie.Model.FailedS3Resource")]
    [AWSCmdlet("Calls the Amazon Macie DisassociateS3Resources API operation.", Operation = new[] {"DisassociateS3Resources"})]
    [AWSCmdletOutput("Amazon.Macie.Model.FailedS3Resource",
        "This cmdlet returns a collection of FailedS3Resource objects.",
        "The service call response (type Amazon.Macie.Model.DisassociateS3ResourcesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RemoveMACS3ResourceCmdlet : AmazonMacieClientCmdlet, IExecutor
    {
        
        #region Parameter AssociatedS3Resource
        /// <summary>
        /// <para>
        /// <para>The S3 resources (buckets or prefixes) that you want to remove from being monitored
        /// and classified by Amazon Macie. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("AssociatedS3Resources")]
        public Amazon.Macie.Model.S3Resource[] AssociatedS3Resource { get; set; }
        #endregion
        
        #region Parameter MemberAccountId
        /// <summary>
        /// <para>
        /// <para>The ID of the Amazon Macie member account whose resources you want to remove from
        /// being monitored by Amazon Macie. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String MemberAccountId { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("MemberAccountId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-MACS3Resource (DisassociateS3Resources)"))
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
            
            if (this.AssociatedS3Resource != null)
            {
                context.AssociatedS3Resources = new List<Amazon.Macie.Model.S3Resource>(this.AssociatedS3Resource);
            }
            context.MemberAccountId = this.MemberAccountId;
            
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
            var request = new Amazon.Macie.Model.DisassociateS3ResourcesRequest();
            
            if (cmdletContext.AssociatedS3Resources != null)
            {
                request.AssociatedS3Resources = cmdletContext.AssociatedS3Resources;
            }
            if (cmdletContext.MemberAccountId != null)
            {
                request.MemberAccountId = cmdletContext.MemberAccountId;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.FailedS3Resources;
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
        
        private Amazon.Macie.Model.DisassociateS3ResourcesResponse CallAWSServiceOperation(IAmazonMacie client, Amazon.Macie.Model.DisassociateS3ResourcesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Macie", "DisassociateS3Resources");
            try
            {
                #if DESKTOP
                return client.DisassociateS3Resources(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.DisassociateS3ResourcesAsync(request);
                return task.Result;
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
            public List<Amazon.Macie.Model.S3Resource> AssociatedS3Resources { get; set; }
            public System.String MemberAccountId { get; set; }
        }
        
    }
}
