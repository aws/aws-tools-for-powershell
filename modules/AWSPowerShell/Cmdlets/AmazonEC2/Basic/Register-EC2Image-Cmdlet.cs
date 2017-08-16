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
    /// You can also use <code>RegisterImage</code> to create an Amazon EBS-backed Linux AMI
    /// from a snapshot of a root device volume. You specify the snapshot using the block
    /// device mapping. For more information, see <a href="http://docs.aws.amazon.com/AWSEC2/latest/UserGuide/instance-launch-snapshot.html">Launching
    /// a Linux Instance from a Backup</a> in the <i>Amazon Elastic Compute Cloud User Guide</i>.
    /// </para><para>
    /// You can't register an image where a secondary (non-root) snapshot has AWS Marketplace
    /// product codes.
    /// </para><para>
    /// Some Linux distributions, such as Red Hat Enterprise Linux (RHEL) and SUSE Linux Enterprise
    /// Server (SLES), use the EC2 billing product code associated with an AMI to verify the
    /// subscription status for package updates. Creating an AMI from an EBS snapshot does
    /// not maintain this billing code, and subsequent instances launched from such an AMI
    /// will not be able to connect to package update infrastructure. To create an AMI that
    /// must retain billing codes, see <a>CreateImage</a>.
    /// </para><para>
    /// If needed, you can deregister an AMI at any time. Any modifications you make to an
    /// AMI backed by an instance store volume invalidates its registration. If you make changes
    /// to an image, deregister the previous image and register the new image.
    /// </para>
    /// </summary>
    [Cmdlet("Register", "EC2Image", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Invokes the RegisterImage operation against Amazon Elastic Compute Cloud.", Operation = new[] {"RegisterImage"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.EC2.Model.RegisterImageResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RegisterEC2ImageCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter Architecture
        /// <summary>
        /// <para>
        /// <para>The architecture of the AMI.</para><para>Default: For Amazon EBS-backed AMIs, <code>i386</code>. For instance store-backed
        /// AMIs, the architecture specified in the manifest file.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.EC2.ArchitectureValues")]
        public Amazon.EC2.ArchitectureValues Architecture { get; set; }
        #endregion
        
        #region Parameter BillingProduct
        /// <summary>
        /// <para>
        /// <para>The billing product codes. Your account must be authorized to specify billing product
        /// codes. Otherwise, you can use the AWS Marketplace to bill for the use of an AMI.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("BillingProducts")]
        public System.String[] BillingProduct { get; set; }
        #endregion
        
        #region Parameter BlockDeviceMapping
        /// <summary>
        /// <para>
        /// <para>One or more block device mapping entries.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("BlockDeviceMappings")]
        public Amazon.EC2.Model.BlockDeviceMapping[] BlockDeviceMapping { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description for your AMI.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter EnaSupport
        /// <summary>
        /// <para>
        /// <para>Set to <code>true</code> to enable enhanced networking with ENA for the AMI and any
        /// instances that you launch from the AMI.</para><para>This option is supported only for HVM AMIs. Specifying this option with a PV AMI can
        /// make instances launched from the AMI unreachable.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean EnaSupport { get; set; }
        #endregion
        
        #region Parameter ImageLocation
        /// <summary>
        /// <para>
        /// <para>The full path to your AMI manifest in Amazon S3 storage.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String ImageLocation { get; set; }
        #endregion
        
        #region Parameter KernelId
        /// <summary>
        /// <para>
        /// <para>The ID of the kernel.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String KernelId { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>A name for your AMI.</para><para>Constraints: 3-128 alphanumeric characters, parentheses (()), square brackets ([]),
        /// spaces ( ), periods (.), slashes (/), dashes (-), single quotes ('), at-signs (@),
        /// or underscores(_)</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter RamdiskId
        /// <summary>
        /// <para>
        /// <para>The ID of the RAM disk.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String RamdiskId { get; set; }
        #endregion
        
        #region Parameter RootDeviceName
        /// <summary>
        /// <para>
        /// <para>The name of the root device (for example, <code>/dev/sda1</code>, or <code>/dev/xvda</code>).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String RootDeviceName { get; set; }
        #endregion
        
        #region Parameter SriovNetSupport
        /// <summary>
        /// <para>
        /// <para>Set to <code>simple</code> to enable enhanced networking with the Intel 82599 Virtual
        /// Function interface for the AMI and any instances that you launch from the AMI.</para><para>There is no way to disable <code>sriovNetSupport</code> at this time.</para><para>This option is supported only for HVM AMIs. Specifying this option with a PV AMI can
        /// make instances launched from the AMI unreachable.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String SriovNetSupport { get; set; }
        #endregion
        
        #region Parameter VirtualizationType
        /// <summary>
        /// <para>
        /// <para>The type of virtualization.</para><para>Default: <code>paravirtual</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String VirtualizationType { get; set; }
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
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.Architecture = this.Architecture;
            if (this.BillingProduct != null)
            {
                context.BillingProducts = new List<System.String>(this.BillingProduct);
            }
            if (this.BlockDeviceMapping != null)
            {
                context.BlockDeviceMappings = new List<Amazon.EC2.Model.BlockDeviceMapping>(this.BlockDeviceMapping);
            }
            context.Description = this.Description;
            if (ParameterWasBound("EnaSupport"))
                context.EnaSupport = this.EnaSupport;
            context.ImageLocation = this.ImageLocation;
            context.KernelId = this.KernelId;
            context.Name = this.Name;
            context.RamdiskId = this.RamdiskId;
            context.RootDeviceName = this.RootDeviceName;
            context.SriovNetSupport = this.SriovNetSupport;
            context.VirtualizationType = this.VirtualizationType;
            
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
            var request = new Amazon.EC2.Model.RegisterImageRequest();
            
            if (cmdletContext.Architecture != null)
            {
                request.Architecture = cmdletContext.Architecture;
            }
            if (cmdletContext.BillingProducts != null)
            {
                request.BillingProducts = cmdletContext.BillingProducts;
            }
            if (cmdletContext.BlockDeviceMappings != null)
            {
                request.BlockDeviceMappings = cmdletContext.BlockDeviceMappings;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.EnaSupport != null)
            {
                request.EnaSupport = cmdletContext.EnaSupport.Value;
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
        
        private Amazon.EC2.Model.RegisterImageResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.RegisterImageRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud", "RegisterImage");
            try
            {
                #if DESKTOP
                return client.RegisterImage(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.RegisterImageAsync(request);
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
            public Amazon.EC2.ArchitectureValues Architecture { get; set; }
            public List<System.String> BillingProducts { get; set; }
            public List<Amazon.EC2.Model.BlockDeviceMapping> BlockDeviceMappings { get; set; }
            public System.String Description { get; set; }
            public System.Boolean? EnaSupport { get; set; }
            public System.String ImageLocation { get; set; }
            public System.String KernelId { get; set; }
            public System.String Name { get; set; }
            public System.String RamdiskId { get; set; }
            public System.String RootDeviceName { get; set; }
            public System.String SriovNetSupport { get; set; }
            public System.String VirtualizationType { get; set; }
        }
        
    }
}
