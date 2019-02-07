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
    /// Creates an Amazon EBS-backed AMI from an Amazon EBS-backed instance that is either
    /// running or stopped.
    /// 
    ///  
    /// <para>
    /// If you customized your instance with instance store volumes or EBS volumes in addition
    /// to the root device volume, the new AMI contains block device mapping information for
    /// those volumes. When you launch an instance from this new AMI, the instance automatically
    /// launches with those additional volumes.
    /// </para><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/creating-an-ami-ebs.html">Creating
    /// Amazon EBS-Backed Linux AMIs</a> in the <i>Amazon Elastic Compute Cloud User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "EC2Image", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud CreateImage API operation.", Operation = new[] {"CreateImage"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.EC2.Model.CreateImageResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewEC2ImageCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter BlockDeviceMapping
        /// <summary>
        /// <para>
        /// <para>Information about one or more block device mappings. This parameter cannot be used
        /// to modify the encryption status of existing volumes or snapshots. To create an AMI
        /// with encrypted snapshots, use the <a>CopyImage</a> action.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 4)]
        [Alias("BlockDeviceMappings")]
        public Amazon.EC2.Model.BlockDeviceMapping[] BlockDeviceMapping { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description for the new image.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter InstanceId
        /// <summary>
        /// <para>
        /// <para>The ID of the instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String InstanceId { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>A name for the new image.</para><para>Constraints: 3-128 alphanumeric characters, parentheses (()), square brackets ([]),
        /// spaces ( ), periods (.), slashes (/), dashes (-), single quotes ('), at-signs (@),
        /// or underscores(_)</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter NoReboot
        /// <summary>
        /// <para>
        /// <para>By default, Amazon EC2 attempts to shut down and reboot the instance before creating
        /// the image. If the 'No Reboot' option is set, Amazon EC2 doesn't shut down the instance
        /// before creating the image. When this option is used, file system integrity on the
        /// created image can't be guaranteed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 3)]
        public System.Boolean NoReboot { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("InstanceId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EC2Image (CreateImage)"))
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
            
            if (this.BlockDeviceMapping != null)
            {
                context.BlockDeviceMappings = new List<Amazon.EC2.Model.BlockDeviceMapping>(this.BlockDeviceMapping);
            }
            context.Description = this.Description;
            context.InstanceId = this.InstanceId;
            context.Name = this.Name;
            if (ParameterWasBound("NoReboot"))
                context.NoReboot = this.NoReboot;
            
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
            var request = new Amazon.EC2.Model.CreateImageRequest();
            
            if (cmdletContext.BlockDeviceMappings != null)
            {
                request.BlockDeviceMappings = cmdletContext.BlockDeviceMappings;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.InstanceId != null)
            {
                request.InstanceId = cmdletContext.InstanceId;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.NoReboot != null)
            {
                request.NoReboot = cmdletContext.NoReboot.Value;
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
        
        private Amazon.EC2.Model.CreateImageResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.CreateImageRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud", "CreateImage");
            try
            {
                #if DESKTOP
                return client.CreateImage(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateImageAsync(request);
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
            public List<Amazon.EC2.Model.BlockDeviceMapping> BlockDeviceMappings { get; set; }
            public System.String Description { get; set; }
            public System.String InstanceId { get; set; }
            public System.String Name { get; set; }
            public System.Boolean? NoReboot { get; set; }
        }
        
    }
}
