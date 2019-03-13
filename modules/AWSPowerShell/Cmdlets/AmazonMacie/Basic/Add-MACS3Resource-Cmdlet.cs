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
    /// Associates specified S3 resources with Amazon Macie for monitoring and data classification.
    /// If memberAccountId isn't specified, the action associates specified S3 resources with
    /// Macie for the current master account. If memberAccountId is specified, the action
    /// associates specified S3 resources with Macie for the specified member account.
    /// </summary>
    [Cmdlet("Add", "MACS3Resource", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Macie.Model.FailedS3Resource")]
    [AWSCmdlet("Calls the Amazon Macie AssociateS3Resources API operation.", Operation = new[] {"AssociateS3Resources"})]
    [AWSCmdletOutput("Amazon.Macie.Model.FailedS3Resource",
        "This cmdlet returns a collection of FailedS3Resource objects.",
        "The service call response (type Amazon.Macie.Model.AssociateS3ResourcesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class AddMACS3ResourceCmdlet : AmazonMacieClientCmdlet, IExecutor
    {
        
        #region Parameter MemberAccountId
        /// <summary>
        /// <para>
        /// <para>The ID of the Amazon Macie member account whose resources you want to associate with
        /// Macie. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String MemberAccountId { get; set; }
        #endregion
        
        #region Parameter S3Resource
        /// <summary>
        /// <para>
        /// <para>The S3 resources that you want to associate with Amazon Macie for monitoring and data
        /// classification. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("S3Resources")]
        public Amazon.Macie.Model.S3ResourceClassification[] S3Resource { get; set; }
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Add-MACS3Resource (AssociateS3Resources)"))
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
            
            context.MemberAccountId = this.MemberAccountId;
            if (this.S3Resource != null)
            {
                context.S3Resources = new List<Amazon.Macie.Model.S3ResourceClassification>(this.S3Resource);
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
            var request = new Amazon.Macie.Model.AssociateS3ResourcesRequest();
            
            if (cmdletContext.MemberAccountId != null)
            {
                request.MemberAccountId = cmdletContext.MemberAccountId;
            }
            if (cmdletContext.S3Resources != null)
            {
                request.S3Resources = cmdletContext.S3Resources;
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
        
        private Amazon.Macie.Model.AssociateS3ResourcesResponse CallAWSServiceOperation(IAmazonMacie client, Amazon.Macie.Model.AssociateS3ResourcesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Macie", "AssociateS3Resources");
            try
            {
                #if DESKTOP
                return client.AssociateS3Resources(request);
                #elif CORECLR
                return client.AssociateS3ResourcesAsync(request).GetAwaiter().GetResult();
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
            public System.String MemberAccountId { get; set; }
            public List<Amazon.Macie.Model.S3ResourceClassification> S3Resources { get; set; }
        }
        
    }
}
