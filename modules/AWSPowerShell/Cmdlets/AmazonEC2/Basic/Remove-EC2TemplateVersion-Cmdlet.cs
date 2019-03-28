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
    /// Deletes one or more versions of a launch template. You cannot delete the default version
    /// of a launch template; you must first assign a different version as the default. If
    /// the default version is the only version for the launch template, you must delete the
    /// entire launch template using <a>DeleteLaunchTemplate</a>.
    /// </summary>
    [Cmdlet("Remove", "EC2TemplateVersion", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("Amazon.EC2.Model.DeleteLaunchTemplateVersionsResponse")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud DeleteLaunchTemplateVersions API operation.", Operation = new[] {"DeleteLaunchTemplateVersions"})]
    [AWSCmdletOutput("Amazon.EC2.Model.DeleteLaunchTemplateVersionsResponse",
        "This cmdlet returns a Amazon.EC2.Model.DeleteLaunchTemplateVersionsResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RemoveEC2TemplateVersionCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter LaunchTemplateId
        /// <summary>
        /// <para>
        /// <para>The ID of the launch template. You must specify either the launch template ID or launch
        /// template name in the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String LaunchTemplateId { get; set; }
        #endregion
        
        #region Parameter LaunchTemplateName
        /// <summary>
        /// <para>
        /// <para>The name of the launch template. You must specify either the launch template ID or
        /// launch template name in the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String LaunchTemplateName { get; set; }
        #endregion
        
        #region Parameter Version
        /// <summary>
        /// <para>
        /// <para>The version numbers of one or more launch template versions to delete.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Versions")]
        public System.String[] Version { get; set; }
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-EC2TemplateVersion (DeleteLaunchTemplateVersions)"))
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
            
            context.LaunchTemplateId = this.LaunchTemplateId;
            context.LaunchTemplateName = this.LaunchTemplateName;
            if (this.Version != null)
            {
                context.Versions = new List<System.String>(this.Version);
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
            var request = new Amazon.EC2.Model.DeleteLaunchTemplateVersionsRequest();
            
            if (cmdletContext.LaunchTemplateId != null)
            {
                request.LaunchTemplateId = cmdletContext.LaunchTemplateId;
            }
            if (cmdletContext.LaunchTemplateName != null)
            {
                request.LaunchTemplateName = cmdletContext.LaunchTemplateName;
            }
            if (cmdletContext.Versions != null)
            {
                request.Versions = cmdletContext.Versions;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response;
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
        
        private Amazon.EC2.Model.DeleteLaunchTemplateVersionsResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.DeleteLaunchTemplateVersionsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud", "DeleteLaunchTemplateVersions");
            try
            {
                #if DESKTOP
                return client.DeleteLaunchTemplateVersions(request);
                #elif CORECLR
                return client.DeleteLaunchTemplateVersionsAsync(request).GetAwaiter().GetResult();
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
            public System.String LaunchTemplateId { get; set; }
            public System.String LaunchTemplateName { get; set; }
            public List<System.String> Versions { get; set; }
        }
        
    }
}
