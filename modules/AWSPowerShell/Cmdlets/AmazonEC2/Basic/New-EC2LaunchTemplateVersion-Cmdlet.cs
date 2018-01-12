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
    /// Creates a new version for a launch template. You can specify an existing version of
    /// launch template from which to base the new version.
    /// 
    ///  
    /// <para>
    /// Launch template versions are numbered in the order in which they are created. You
    /// cannot specify, change, or replace the numbering of launch template versions.
    /// </para>
    /// </summary>
    [Cmdlet("New", "EC2LaunchTemplateVersion", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.LaunchTemplateVersion")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud CreateLaunchTemplateVersion API operation.", Operation = new[] {"CreateLaunchTemplateVersion"})]
    [AWSCmdletOutput("Amazon.EC2.Model.LaunchTemplateVersion",
        "This cmdlet returns a LaunchTemplateVersion object.",
        "The service call response (type Amazon.EC2.Model.CreateLaunchTemplateVersionResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewEC2LaunchTemplateVersionCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Unique, case-sensitive identifier you provide to ensure the idempotency of the request.
        /// For more information, see <a href="http://docs.aws.amazon.com/AWSEC2/latest/APIReference/Run_Instance_Idempotency.html">Ensuring
        /// Idempotency</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter LaunchTemplateData
        /// <summary>
        /// <para>
        /// <para>The information for the launch template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public Amazon.EC2.Model.RequestLaunchTemplateData LaunchTemplateData { get; set; }
        #endregion
        
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
        
        #region Parameter SourceVersion
        /// <summary>
        /// <para>
        /// <para>The version number of the launch template version on which to base the new version.
        /// The new version inherits the same launch parameters as the source version, except
        /// for parameters that you specify in LaunchTemplateData.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String SourceVersion { get; set; }
        #endregion
        
        #region Parameter VersionDescription
        /// <summary>
        /// <para>
        /// <para>A description for the version of the launch template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String VersionDescription { get; set; }
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EC2LaunchTemplateVersion (CreateLaunchTemplateVersion)"))
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
            
            context.ClientToken = this.ClientToken;
            context.LaunchTemplateData = this.LaunchTemplateData;
            context.LaunchTemplateId = this.LaunchTemplateId;
            context.LaunchTemplateName = this.LaunchTemplateName;
            context.SourceVersion = this.SourceVersion;
            context.VersionDescription = this.VersionDescription;
            
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
            var request = new Amazon.EC2.Model.CreateLaunchTemplateVersionRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.LaunchTemplateData != null)
            {
                request.LaunchTemplateData = cmdletContext.LaunchTemplateData;
            }
            if (cmdletContext.LaunchTemplateId != null)
            {
                request.LaunchTemplateId = cmdletContext.LaunchTemplateId;
            }
            if (cmdletContext.LaunchTemplateName != null)
            {
                request.LaunchTemplateName = cmdletContext.LaunchTemplateName;
            }
            if (cmdletContext.SourceVersion != null)
            {
                request.SourceVersion = cmdletContext.SourceVersion;
            }
            if (cmdletContext.VersionDescription != null)
            {
                request.VersionDescription = cmdletContext.VersionDescription;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.LaunchTemplateVersion;
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
        
        private Amazon.EC2.Model.CreateLaunchTemplateVersionResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.CreateLaunchTemplateVersionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud", "CreateLaunchTemplateVersion");
            try
            {
                #if DESKTOP
                return client.CreateLaunchTemplateVersion(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateLaunchTemplateVersionAsync(request);
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
            public System.String ClientToken { get; set; }
            public Amazon.EC2.Model.RequestLaunchTemplateData LaunchTemplateData { get; set; }
            public System.String LaunchTemplateId { get; set; }
            public System.String LaunchTemplateName { get; set; }
            public System.String SourceVersion { get; set; }
            public System.String VersionDescription { get; set; }
        }
        
    }
}
