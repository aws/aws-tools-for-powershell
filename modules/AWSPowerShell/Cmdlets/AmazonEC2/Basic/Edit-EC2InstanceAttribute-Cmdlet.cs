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
    /// Modifies the specified attribute of the specified instance. You can specify only one
    /// attribute at a time.
    /// 
    ///  
    /// <para>
    /// To modify some attributes, the instance must be stopped. For more information, see
    /// <a href="http://docs.aws.amazon.com/AWSEC2/latest/UserGuide/Using_ChangingAttributesWhileInstanceStopped.html">Modifying
    /// Attributes of a Stopped Instance</a> in the <i>Amazon Elastic Compute Cloud User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Edit", "EC2InstanceAttribute", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Invokes the ModifyInstanceAttribute operation against Amazon Elastic Compute Cloud.", Operation = new[] {"ModifyInstanceAttribute"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the InstanceId parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.EC2.Model.ModifyInstanceAttributeResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class EditEC2InstanceAttributeCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter Attribute
        /// <summary>
        /// <para>
        /// <para>The name of the attribute.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.EC2.InstanceAttributeName")]
        public Amazon.EC2.InstanceAttributeName Attribute { get; set; }
        #endregion
        
        #region Parameter BlockDeviceMapping
        /// <summary>
        /// <para>
        /// <para>Modifies the <code>DeleteOnTermination</code> attribute for volumes that are currently
        /// attached. The volume must be owned by the caller. If no value is specified for <code>DeleteOnTermination</code>,
        /// the default is <code>true</code> and the volume is deleted when the instance is terminated.</para><para>To add instance store volumes to an Amazon EBS-backed instance, you must add them
        /// when you launch the instance. For more information, see <a href="http://docs.aws.amazon.com/AWSEC2/latest/UserGuide/block-device-mapping-concepts.html#Using_OverridingAMIBDM">Updating
        /// the Block Device Mapping when Launching an Instance</a> in the <i>Amazon Elastic Compute
        /// Cloud User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("BlockDeviceMappings")]
        public Amazon.EC2.Model.InstanceBlockDeviceMappingSpecification[] BlockDeviceMapping { get; set; }
        #endregion
        
        #region Parameter DisableApiTermination
        /// <summary>
        /// <para>
        /// <para>If the value is <code>true</code>, you can't terminate the instance using the Amazon
        /// EC2 console, CLI, or API; otherwise, you can. You cannot use this parameter for Spot
        /// Instances.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean DisableApiTermination { get; set; }
        #endregion
        
        #region Parameter EbsOptimized
        /// <summary>
        /// <para>
        /// <para>Specifies whether the instance is optimized for Amazon EBS I/O. This optimization
        /// provides dedicated throughput to Amazon EBS and an optimized configuration stack to
        /// provide optimal EBS I/O performance. This optimization isn't available with all instance
        /// types. Additional usage charges apply when using an EBS Optimized instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean EbsOptimized { get; set; }
        #endregion
        
        #region Parameter EnaSupport
        /// <summary>
        /// <para>
        /// <para>Set to <code>true</code> to enable enhanced networking with ENA for the instance.</para><para>This option is supported only for HVM instances. Specifying this option with a PV
        /// instance can make it unreachable.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean EnaSupport { get; set; }
        #endregion
        
        #region Parameter Group
        /// <summary>
        /// <para>
        /// <para>[EC2-VPC] Changes the security groups of the instance. You must specify at least one
        /// security group, even if it's just the default security group for the VPC. You must
        /// specify the security group ID, not the security group name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("GroupId","Groups")]
        public System.String[] Group { get; set; }
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
        
        #region Parameter InstanceInitiatedShutdownBehavior
        /// <summary>
        /// <para>
        /// <para>Specifies whether an instance stops or terminates when you initiate shutdown from
        /// the instance (using the operating system command for system shutdown).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String InstanceInitiatedShutdownBehavior { get; set; }
        #endregion
        
        #region Parameter InstanceType
        /// <summary>
        /// <para>
        /// <para>Changes the instance type to the specified value. For more information, see <a href="http://docs.aws.amazon.com/AWSEC2/latest/UserGuide/instance-types.html">Instance
        /// Types</a>. If the instance type is not valid, the error returned is <code>InvalidInstanceAttributeValue</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String InstanceType { get; set; }
        #endregion
        
        #region Parameter Kernel
        /// <summary>
        /// <para>
        /// <para>Changes the instance's kernel to the specified value. We recommend that you use PV-GRUB
        /// instead of kernels and RAM disks. For more information, see <a href="http://docs.aws.amazon.com/AWSEC2/latest/UserGuide/UserProvidedKernels.html">PV-GRUB</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Kernel { get; set; }
        #endregion
        
        #region Parameter Ramdisk
        /// <summary>
        /// <para>
        /// <para>Changes the instance's RAM disk to the specified value. We recommend that you use
        /// PV-GRUB instead of kernels and RAM disks. For more information, see <a href="http://docs.aws.amazon.com/AWSEC2/latest/UserGuide/UserProvidedKernels.html">PV-GRUB</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Ramdisk { get; set; }
        #endregion
        
        #region Parameter SourceDestCheck
        /// <summary>
        /// <para>
        /// <para>Specifies whether source/destination checking is enabled. A value of <code>true</code>
        /// means that checking is enabled, and <code>false</code> means that checking is disabled.
        /// This value must be <code>false</code> for a NAT instance to perform NAT.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean SourceDestCheck { get; set; }
        #endregion
        
        #region Parameter SriovNetSupport
        /// <summary>
        /// <para>
        /// <para>Set to <code>simple</code> to enable enhanced networking with the Intel 82599 Virtual
        /// Function interface for the instance.</para><para>There is no way to disable enhanced networking with the Intel 82599 Virtual Function
        /// interface at this time.</para><para>This option is supported only for HVM instances. Specifying this option with a PV
        /// instance can make it unreachable.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String SriovNetSupport { get; set; }
        #endregion
        
        #region Parameter UserData
        /// <summary>
        /// <para>
        /// <para>Changes the instance's user data to the specified value. If you are using an AWS SDK
        /// or command line tool, base64-encoding is performed for you, and you can load the text
        /// from a file. Otherwise, you must provide base64-encoded text.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String UserData { get; set; }
        #endregion
        
        #region Parameter Value
        /// <summary>
        /// <para>
        /// <para>A new value for the attribute. Use only with the <code>kernel</code>, <code>ramdisk</code>,
        /// <code>userData</code>, <code>disableApiTermination</code>, or <code>instanceInitiatedShutdownBehavior</code>
        /// attribute.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Value { get; set; }
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Returns the value passed to the InstanceId parameter.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("InstanceId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-EC2InstanceAttribute (ModifyInstanceAttribute)"))
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
            
            context.Attribute = this.Attribute;
            if (this.BlockDeviceMapping != null)
            {
                context.BlockDeviceMappings = new List<Amazon.EC2.Model.InstanceBlockDeviceMappingSpecification>(this.BlockDeviceMapping);
            }
            if (ParameterWasBound("DisableApiTermination"))
                context.DisableApiTermination = this.DisableApiTermination;
            if (ParameterWasBound("EbsOptimized"))
                context.EbsOptimized = this.EbsOptimized;
            if (ParameterWasBound("EnaSupport"))
                context.EnaSupport = this.EnaSupport;
            if (this.Group != null)
            {
                context.Groups = new List<System.String>(this.Group);
            }
            context.InstanceId = this.InstanceId;
            context.InstanceInitiatedShutdownBehavior = this.InstanceInitiatedShutdownBehavior;
            context.InstanceType = this.InstanceType;
            context.Kernel = this.Kernel;
            context.Ramdisk = this.Ramdisk;
            if (ParameterWasBound("SourceDestCheck"))
                context.SourceDestCheck = this.SourceDestCheck;
            context.SriovNetSupport = this.SriovNetSupport;
            context.UserData = this.UserData;
            context.Value = this.Value;
            
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
            var request = new Amazon.EC2.Model.ModifyInstanceAttributeRequest();
            
            if (cmdletContext.Attribute != null)
            {
                request.Attribute = cmdletContext.Attribute;
            }
            if (cmdletContext.BlockDeviceMappings != null)
            {
                request.BlockDeviceMappings = cmdletContext.BlockDeviceMappings;
            }
            if (cmdletContext.DisableApiTermination != null)
            {
                request.DisableApiTermination = cmdletContext.DisableApiTermination.Value;
            }
            if (cmdletContext.EbsOptimized != null)
            {
                request.EbsOptimized = cmdletContext.EbsOptimized.Value;
            }
            if (cmdletContext.EnaSupport != null)
            {
                request.EnaSupport = cmdletContext.EnaSupport.Value;
            }
            if (cmdletContext.Groups != null)
            {
                request.Groups = cmdletContext.Groups;
            }
            if (cmdletContext.InstanceId != null)
            {
                request.InstanceId = cmdletContext.InstanceId;
            }
            if (cmdletContext.InstanceInitiatedShutdownBehavior != null)
            {
                request.InstanceInitiatedShutdownBehavior = cmdletContext.InstanceInitiatedShutdownBehavior;
            }
            if (cmdletContext.InstanceType != null)
            {
                request.InstanceType = cmdletContext.InstanceType;
            }
            if (cmdletContext.Kernel != null)
            {
                request.Kernel = cmdletContext.Kernel;
            }
            if (cmdletContext.Ramdisk != null)
            {
                request.Ramdisk = cmdletContext.Ramdisk;
            }
            if (cmdletContext.SourceDestCheck != null)
            {
                request.SourceDestCheck = cmdletContext.SourceDestCheck.Value;
            }
            if (cmdletContext.SriovNetSupport != null)
            {
                request.SriovNetSupport = cmdletContext.SriovNetSupport;
            }
            if (cmdletContext.UserData != null)
            {
                request.UserData = cmdletContext.UserData;
            }
            if (cmdletContext.Value != null)
            {
                request.Value = cmdletContext.Value;
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
                    pipelineOutput = this.InstanceId;
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
        
        private Amazon.EC2.Model.ModifyInstanceAttributeResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.ModifyInstanceAttributeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud", "ModifyInstanceAttribute");
            try
            {
                #if DESKTOP
                return client.ModifyInstanceAttribute(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.ModifyInstanceAttributeAsync(request);
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
            public Amazon.EC2.InstanceAttributeName Attribute { get; set; }
            public List<Amazon.EC2.Model.InstanceBlockDeviceMappingSpecification> BlockDeviceMappings { get; set; }
            public System.Boolean? DisableApiTermination { get; set; }
            public System.Boolean? EbsOptimized { get; set; }
            public System.Boolean? EnaSupport { get; set; }
            public List<System.String> Groups { get; set; }
            public System.String InstanceId { get; set; }
            public System.String InstanceInitiatedShutdownBehavior { get; set; }
            public System.String InstanceType { get; set; }
            public System.String Kernel { get; set; }
            public System.String Ramdisk { get; set; }
            public System.Boolean? SourceDestCheck { get; set; }
            public System.String SriovNetSupport { get; set; }
            public System.String UserData { get; set; }
            public System.String Value { get; set; }
        }
        
    }
}
