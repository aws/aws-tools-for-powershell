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
    /// Stops the directory sharing between the directory owner and consumer accounts.
    /// </summary>
    [Cmdlet("Disable", "DSDirectoryShare", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Directory Service UnshareDirectory API operation.", Operation = new[] {"UnshareDirectory"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.DirectoryService.Model.UnshareDirectoryResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class DisableDSDirectoryShareCmdlet : AmazonDirectoryServiceClientCmdlet, IExecutor
    {
        
        #region Parameter DirectoryId
        /// <summary>
        /// <para>
        /// <para>The identifier of the AWS Managed Microsoft AD directory that you want to stop sharing.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String DirectoryId { get; set; }
        #endregion
        
        #region Parameter UnshareTarget_Id
        /// <summary>
        /// <para>
        /// <para>Identifier of the directory consumer account.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String UnshareTarget_Id { get; set; }
        #endregion
        
        #region Parameter UnshareTarget_Type
        /// <summary>
        /// <para>
        /// <para>Type of identifier to be used in the <i>Id</i> field.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.DirectoryService.TargetType")]
        public Amazon.DirectoryService.TargetType UnshareTarget_Type { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("DirectoryId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Disable-DSDirectoryShare (UnshareDirectory)"))
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
            
            context.DirectoryId = this.DirectoryId;
            context.UnshareTarget_Id = this.UnshareTarget_Id;
            context.UnshareTarget_Type = this.UnshareTarget_Type;
            
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
            var request = new Amazon.DirectoryService.Model.UnshareDirectoryRequest();
            
            if (cmdletContext.DirectoryId != null)
            {
                request.DirectoryId = cmdletContext.DirectoryId;
            }
            
             // populate UnshareTarget
            bool requestUnshareTargetIsNull = true;
            request.UnshareTarget = new Amazon.DirectoryService.Model.UnshareTarget();
            System.String requestUnshareTarget_unshareTarget_Id = null;
            if (cmdletContext.UnshareTarget_Id != null)
            {
                requestUnshareTarget_unshareTarget_Id = cmdletContext.UnshareTarget_Id;
            }
            if (requestUnshareTarget_unshareTarget_Id != null)
            {
                request.UnshareTarget.Id = requestUnshareTarget_unshareTarget_Id;
                requestUnshareTargetIsNull = false;
            }
            Amazon.DirectoryService.TargetType requestUnshareTarget_unshareTarget_Type = null;
            if (cmdletContext.UnshareTarget_Type != null)
            {
                requestUnshareTarget_unshareTarget_Type = cmdletContext.UnshareTarget_Type;
            }
            if (requestUnshareTarget_unshareTarget_Type != null)
            {
                request.UnshareTarget.Type = requestUnshareTarget_unshareTarget_Type;
                requestUnshareTargetIsNull = false;
            }
             // determine if request.UnshareTarget should be set to null
            if (requestUnshareTargetIsNull)
            {
                request.UnshareTarget = null;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.SharedDirectoryId;
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
        
        private Amazon.DirectoryService.Model.UnshareDirectoryResponse CallAWSServiceOperation(IAmazonDirectoryService client, Amazon.DirectoryService.Model.UnshareDirectoryRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Directory Service", "UnshareDirectory");
            try
            {
                #if DESKTOP
                return client.UnshareDirectory(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.UnshareDirectoryAsync(request);
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
            public System.String DirectoryId { get; set; }
            public System.String UnshareTarget_Id { get; set; }
            public Amazon.DirectoryService.TargetType UnshareTarget_Type { get; set; }
        }
        
    }
}
