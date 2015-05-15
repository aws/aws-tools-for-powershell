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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Registers an AMI. When you're creating an AMI, this is the final step you must complete
    /// before you can launch an instance from the AMI. For more information about creating
    /// AMIs, see <a href="http://docs.aws.amazon.com/AWSEC2/latest/UserGuide/creating-an-ami.html">Creating
    /// Your Own AMIs</a> in the <i>Amazon Elastic Compute Cloud User Guide</i>.
    /// 
    ///  <note><para>
    /// For Amazon EBS-backed instances, <a>CreateImage</a> creates and registers the AMI
    /// in a single request, so you don't have to register the AMI yourself.
    /// </para></note><para>
    /// You can also use <code>RegisterImage</code> to create an Amazon EBS-backed AMI from
    /// a snapshot of a root device volume. For more information, see <a href="http://docs.aws.amazon.com/AWSEC2/latest/UserGuide/Using_LaunchingInstanceFromSnapshot.html">Launching
    /// an Instance from a Snapshot</a> in the <i>Amazon Elastic Compute Cloud User Guide</i>.
    /// </para><para>
    /// If needed, you can deregister an AMI at any time. Any modifications you make to an
    /// AMI backed by an instance store volume invalidates its registration. If you make changes
    /// to an image, deregister the previous image and register the new image.
    /// </para><note><para>
    /// You can't register an image where a secondary (non-root) snapshot has AWS Marketplace
    /// product codes.
    /// </para></note>
    /// </summary>
    [Cmdlet("Register", "EC2Image", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Invokes the RegisterImage operation against Amazon Elastic Compute Cloud.", Operation = new[] {"RegisterImage"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type RegisterImageResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class RegisterEC2ImageCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>The architecture of the AMI.</para><para>Default: For Amazon EBS-backed AMIs, <code>i386</code>. For instance store-backed
        /// AMIs, the architecture specified in the manifest file.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public ArchitectureValues Architecture { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>One or more block device mapping entries.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("BlockDeviceMappings")]
        public Amazon.EC2.Model.BlockDeviceMapping[] BlockDeviceMapping { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>A description for your AMI.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2)]
        public String Description { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The full path to your AMI manifest in Amazon S3 storage.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public String ImageLocation { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The ID of the kernel.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String KernelId { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>A name for your AMI.</para><para>Constraints: 3-128 alphanumeric characters, parentheses (()), square brackets ([]),
        /// spaces ( ), periods (.), slashes (/), dashes (-), single quotes ('), at-signs (@),
        /// or underscores(_)</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        public String Name { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The ID of the RAM disk.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String RamdiskId { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The name of the root device (for example, <code>/dev/sda1</code>, or <code>/dev/xvda</code>).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String RootDeviceName { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>Set to <code>simple</code> to enable enhanced networking for the AMI and any instances
        /// that you launch from the AMI.</para><para>There is no way to disable enhanced networking at this time.</para><para>This option is supported only for HVM AMIs. Specifying this option with a PV AMI can
        /// make instances launched from the AMI unreachable.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String SriovNetSupport { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The type of virtualization.</para><para>Default: <code>paravirtual</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String VirtualizationType { get; set; }
        
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ImageLocation", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Register-EC2Image (RegisterImage)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.Architecture = this.Architecture;
            if (this.BlockDeviceMapping != null)
            {
                context.BlockDeviceMappings = new List<BlockDeviceMapping>(this.BlockDeviceMapping);
            }
            context.Description = this.Description;
            context.ImageLocation = this.ImageLocation;
            context.KernelId = this.KernelId;
            context.Name = this.Name;
            context.RamdiskId = this.RamdiskId;
            context.RootDeviceName = this.RootDeviceName;
            context.SriovNetSupport = this.SriovNetSupport;
            context.VirtualizationType = this.VirtualizationType;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new RegisterImageRequest();
            
            if (cmdletContext.Architecture != null)
            {
                request.Architecture = cmdletContext.Architecture;
            }
            if (cmdletContext.BlockDeviceMappings != null)
            {
                request.BlockDeviceMappings = cmdletContext.BlockDeviceMappings;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.ImageLocation != null)
            {
                request.ImageLocation = cmdletContext.ImageLocation;
            }
            if (cmdletContext.KernelId != null)
            {
                request.KernelId = cmdletContext.KernelId;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.RamdiskId != null)
            {
                request.RamdiskId = cmdletContext.RamdiskId;
            }
            if (cmdletContext.RootDeviceName != null)
            {
                request.RootDeviceName = cmdletContext.RootDeviceName;
            }
            if (cmdletContext.SriovNetSupport != null)
            {
                request.SriovNetSupport = cmdletContext.SriovNetSupport;
            }
            if (cmdletContext.VirtualizationType != null)
            {
                request.VirtualizationType = cmdletContext.VirtualizationType;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.RegisterImage(request);
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
        
        
        internal class CmdletContext : ExecutorContext
        {
            public ArchitectureValues Architecture { get; set; }
            public List<BlockDeviceMapping> BlockDeviceMappings { get; set; }
            public String Description { get; set; }
            public String ImageLocation { get; set; }
            public String KernelId { get; set; }
            public String Name { get; set; }
            public String RamdiskId { get; set; }
            public String RootDeviceName { get; set; }
            public String SriovNetSupport { get; set; }
            public String VirtualizationType { get; set; }
        }
        
    }
}
