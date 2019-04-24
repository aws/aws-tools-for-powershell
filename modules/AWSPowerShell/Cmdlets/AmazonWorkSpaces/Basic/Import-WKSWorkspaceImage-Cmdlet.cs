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
using Amazon.WorkSpaces;
using Amazon.WorkSpaces.Model;

namespace Amazon.PowerShell.Cmdlets.WKS
{
    /// <summary>
    /// Imports the specified Windows 7 or Windows 10 bring your own license (BYOL) image
    /// into Amazon WorkSpaces. The image must be an already licensed EC2 image that is in
    /// your AWS account, and you must own the image.
    /// </summary>
    [Cmdlet("Import", "WKSWorkspaceImage", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon WorkSpaces ImportWorkspaceImage API operation.", Operation = new[] {"ImportWorkspaceImage"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.WorkSpaces.Model.ImportWorkspaceImageResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class ImportWKSWorkspaceImageCmdlet : AmazonWorkSpacesClientCmdlet, IExecutor
    {
        
        #region Parameter Ec2ImageId
        /// <summary>
        /// <para>
        /// <para>The identifier of the EC2 image.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Ec2ImageId { get; set; }
        #endregion
        
        #region Parameter ImageDescription
        /// <summary>
        /// <para>
        /// <para>The description of the WorkSpace image.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ImageDescription { get; set; }
        #endregion
        
        #region Parameter ImageName
        /// <summary>
        /// <para>
        /// <para>The name of the WorkSpace image.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String ImageName { get; set; }
        #endregion
        
        #region Parameter IngestionProcess
        /// <summary>
        /// <para>
        /// <para>The ingestion process to be used when importing the image.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.WorkSpaces.WorkspaceImageIngestionProcess")]
        public Amazon.WorkSpaces.WorkspaceImageIngestionProcess IngestionProcess { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags. Each WorkSpaces resource can have a maximum of 50 tags.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Tags")]
        public Amazon.WorkSpaces.Model.Tag[] Tag { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ImageName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Import-WKSWorkspaceImage (ImportWorkspaceImage)"))
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
            
            context.Ec2ImageId = this.Ec2ImageId;
            context.ImageDescription = this.ImageDescription;
            context.ImageName = this.ImageName;
            context.IngestionProcess = this.IngestionProcess;
            if (this.Tag != null)
            {
                context.Tags = new List<Amazon.WorkSpaces.Model.Tag>(this.Tag);
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
            var request = new Amazon.WorkSpaces.Model.ImportWorkspaceImageRequest();
            
            if (cmdletContext.Ec2ImageId != null)
            {
                request.Ec2ImageId = cmdletContext.Ec2ImageId;
            }
            if (cmdletContext.ImageDescription != null)
            {
                request.ImageDescription = cmdletContext.ImageDescription;
            }
            if (cmdletContext.ImageName != null)
            {
                request.ImageName = cmdletContext.ImageName;
            }
            if (cmdletContext.IngestionProcess != null)
            {
                request.IngestionProcess = cmdletContext.IngestionProcess;
            }
            if (cmdletContext.Tags != null)
            {
                request.Tags = cmdletContext.Tags;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.ImageId;
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
        
        private Amazon.WorkSpaces.Model.ImportWorkspaceImageResponse CallAWSServiceOperation(IAmazonWorkSpaces client, Amazon.WorkSpaces.Model.ImportWorkspaceImageRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon WorkSpaces", "ImportWorkspaceImage");
            try
            {
                #if DESKTOP
                return client.ImportWorkspaceImage(request);
                #elif CORECLR
                return client.ImportWorkspaceImageAsync(request).GetAwaiter().GetResult();
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
            public System.String Ec2ImageId { get; set; }
            public System.String ImageDescription { get; set; }
            public System.String ImageName { get; set; }
            public Amazon.WorkSpaces.WorkspaceImageIngestionProcess IngestionProcess { get; set; }
            public List<Amazon.WorkSpaces.Model.Tag> Tags { get; set; }
        }
        
    }
}
