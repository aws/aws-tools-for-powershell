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
    /// Detaches an EBS volume from an instance. Make sure to unmount any file systems on
    /// the device within your operating system before detaching the volume. Failure to do
    /// so can result in the volume becoming stuck in the <code>busy</code> state while detaching.
    /// If this happens, detachment can be delayed indefinitely until you unmount the volume,
    /// force detachment, reboot the instance, or all three. If an EBS volume is the root
    /// device of an instance, it can't be detached while the instance is running. To detach
    /// the root volume, stop the instance first.
    /// 
    ///  
    /// <para>
    /// When a volume with an AWS Marketplace product code is detached from an instance, the
    /// product code is no longer associated with the instance.
    /// </para><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/ebs-detaching-volume.html">Detaching
    /// an Amazon EBS Volume</a> in the <i>Amazon Elastic Compute Cloud User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Dismount", "EC2Volume", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.VolumeAttachment")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud DetachVolume API operation.", Operation = new[] {"DetachVolume"})]
    [AWSCmdletOutput("Amazon.EC2.Model.VolumeAttachment",
        "This cmdlet returns a VolumeAttachment object.",
        "The service call response (type Amazon.EC2.Model.DetachVolumeResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class DismountEC2VolumeCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter Device
        /// <summary>
        /// <para>
        /// <para>The device name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 3)]
        public System.String Device { get; set; }
        #endregion
        
        #region Parameter ForceDismount
        /// <summary>
        /// <para>
        /// <para>Forces detachment if the previous detachment attempt did not occur cleanly (for example,
        /// logging into an instance, unmounting the volume, and detaching normally). This option
        /// can lead to data loss or a corrupted file system. Use this option only as a last resort
        /// to detach a volume from a failed instance. The instance won't have an opportunity
        /// to flush file system caches or file system metadata. If you use this option, you must
        /// perform file system check and repair procedures.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean ForceDismount { get; set; }
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
        
        #region Parameter VolumeId
        /// <summary>
        /// <para>
        /// <para>The ID of the volume.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public System.String VolumeId { get; set; }
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Dismount-EC2Volume (DetachVolume)"))
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
            
            context.Device = this.Device;
            if (ParameterWasBound("ForceDismount"))
                context.ForceDismount = this.ForceDismount;
            context.InstanceId = this.InstanceId;
            context.VolumeId = this.VolumeId;
            
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
            var request = new Amazon.EC2.Model.DetachVolumeRequest();
            
            if (cmdletContext.Device != null)
            {
                request.Device = cmdletContext.Device;
            }
            if (cmdletContext.ForceDismount != null)
            {
                request.Force = cmdletContext.ForceDismount.Value;
            }
            if (cmdletContext.InstanceId != null)
            {
                request.InstanceId = cmdletContext.InstanceId;
            }
            if (cmdletContext.VolumeId != null)
            {
                request.VolumeId = cmdletContext.VolumeId;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Attachment;
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
        
        private Amazon.EC2.Model.DetachVolumeResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.DetachVolumeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud", "DetachVolume");
            try
            {
                #if DESKTOP
                return client.DetachVolume(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.DetachVolumeAsync(request);
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
            public System.String Device { get; set; }
            public System.Boolean? ForceDismount { get; set; }
            public System.String InstanceId { get; set; }
            public System.String VolumeId { get; set; }
        }
        
    }
}
