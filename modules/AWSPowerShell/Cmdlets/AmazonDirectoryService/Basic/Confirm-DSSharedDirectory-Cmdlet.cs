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
using Amazon.DirectoryService;
using Amazon.DirectoryService.Model;

namespace Amazon.PowerShell.Cmdlets.DS
{
    /// <summary>
    /// Accepts a directory sharing request that was sent from the directory owner account.
    /// </summary>
    [Cmdlet("Confirm", "DSSharedDirectory", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DirectoryService.Model.SharedDirectory")]
    [AWSCmdlet("Calls the AWS Directory Service AcceptSharedDirectory API operation.", Operation = new[] {"AcceptSharedDirectory"})]
    [AWSCmdletOutput("Amazon.DirectoryService.Model.SharedDirectory",
        "This cmdlet returns a SharedDirectory object.",
        "The service call response (type Amazon.DirectoryService.Model.AcceptSharedDirectoryResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class ConfirmDSSharedDirectoryCmdlet : AmazonDirectoryServiceClientCmdlet, IExecutor
    {
        
        #region Parameter SharedDirectoryId
        /// <summary>
        /// <para>
        /// <para>Identifier of the shared directory in the directory consumer account. This identifier
        /// is different for each directory owner account. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String SharedDirectoryId { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("SharedDirectoryId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Confirm-DSSharedDirectory (AcceptSharedDirectory)"))
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
            
            context.SharedDirectoryId = this.SharedDirectoryId;
            
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
            var request = new Amazon.DirectoryService.Model.AcceptSharedDirectoryRequest();
            
            if (cmdletContext.SharedDirectoryId != null)
            {
                request.SharedDirectoryId = cmdletContext.SharedDirectoryId;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.SharedDirectory;
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
        
        private Amazon.DirectoryService.Model.AcceptSharedDirectoryResponse CallAWSServiceOperation(IAmazonDirectoryService client, Amazon.DirectoryService.Model.AcceptSharedDirectoryRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Directory Service", "AcceptSharedDirectory");
            try
            {
                #if DESKTOP
                return client.AcceptSharedDirectory(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.AcceptSharedDirectoryAsync(request);
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
            public System.String SharedDirectoryId { get; set; }
        }
        
    }
}
