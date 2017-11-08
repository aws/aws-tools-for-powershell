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
using Amazon.CodeCommit;
using Amazon.CodeCommit.Model;

namespace Amazon.PowerShell.Cmdlets.CC
{
    /// <summary>
    /// Sets or changes the comment or description for a repository.
    /// 
    ///  <note><para>
    /// The description field for a repository accepts all HTML characters and all valid Unicode
    /// characters. Applications that do not HTML-encode the description and display it in
    /// a web page could expose users to potentially malicious code. Make sure that you HTML-encode
    /// the description field in any application that uses this API to display the repository
    /// description on a web page.
    /// </para></note>
    /// </summary>
    [Cmdlet("Update", "CCRepositoryDescription", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Calls the AWS CodeCommit UpdateRepositoryDescription API operation.", Operation = new[] {"UpdateRepositoryDescription"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the RepositoryName parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.CodeCommit.Model.UpdateRepositoryDescriptionResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateCCRepositoryDescriptionCmdlet : AmazonCodeCommitClientCmdlet, IExecutor
    {
        
        #region Parameter RepositoryDescription
        /// <summary>
        /// <para>
        /// <para>The new comment or description for the specified repository. Repository descriptions
        /// are limited to 1,000 characters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String RepositoryDescription { get; set; }
        #endregion
        
        #region Parameter RepositoryName
        /// <summary>
        /// <para>
        /// <para>The name of the repository to set or change the comment or description for.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String RepositoryName { get; set; }
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Returns the value passed to the RepositoryName parameter.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("RepositoryName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CCRepositoryDescription (UpdateRepositoryDescription)"))
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
            
            context.RepositoryDescription = this.RepositoryDescription;
            context.RepositoryName = this.RepositoryName;
            
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
            var request = new Amazon.CodeCommit.Model.UpdateRepositoryDescriptionRequest();
            
            if (cmdletContext.RepositoryDescription != null)
            {
                request.RepositoryDescription = cmdletContext.RepositoryDescription;
            }
            if (cmdletContext.RepositoryName != null)
            {
                request.RepositoryName = cmdletContext.RepositoryName;
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
                    pipelineOutput = this.RepositoryName;
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
        
        private Amazon.CodeCommit.Model.UpdateRepositoryDescriptionResponse CallAWSServiceOperation(IAmazonCodeCommit client, Amazon.CodeCommit.Model.UpdateRepositoryDescriptionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CodeCommit", "UpdateRepositoryDescription");
            try
            {
                #if DESKTOP
                return client.UpdateRepositoryDescription(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.UpdateRepositoryDescriptionAsync(request);
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
            public System.String RepositoryDescription { get; set; }
            public System.String RepositoryName { get; set; }
        }
        
    }
}
