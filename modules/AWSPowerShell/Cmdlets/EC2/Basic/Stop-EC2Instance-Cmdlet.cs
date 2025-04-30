/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Stops an Amazon EBS-backed instance. For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/Stop_Start.html">Stop
    /// and start Amazon EC2 instances</a> in the <i>Amazon EC2 User Guide</i>.
    /// 
    ///  
    /// <para>
    /// When you stop an instance, we shut it down. You can restart your instance at any time.
    /// </para><para>
    /// You can use the Stop operation together with the Hibernate parameter to hibernate
    /// an instance if the instance is <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/enabling-hibernation.html">enabled
    /// for hibernation</a> and meets the <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/hibernating-prerequisites.html">hibernation
    /// prerequisites</a>. Stopping an instance doesn't preserve data stored in RAM, while
    /// hibernation does. If hibernation fails, a normal shutdown occurs. For more information,
    /// see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/Hibernate.html">Hibernate
    /// your Amazon EC2 instance</a> in the <i>Amazon EC2 User Guide</i>.
    /// </para><para>
    /// If your instance appears stuck in the <c>stopping</c> state, there might be an issue
    /// with the underlying host computer. You can use the Stop operation together with the
    /// Force parameter to force stop your instance. For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/TroubleshootingInstancesStopping.html">Troubleshoot
    /// Amazon EC2 instance stop issues</a> in the <i>Amazon EC2 User Guide</i>.
    /// </para><para>
    /// Stopping and hibernating an instance differs from rebooting or terminating it. For
    /// example, a stopped or hibernated instance retains its root volume and any data volumes,
    /// unlike terminated instances where these volumes are automatically deleted. For more
    /// information about the differences between stopping, hibernating, rebooting, and terminating
    /// instances, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/ec2-instance-lifecycle.html">Amazon
    /// EC2 instance state changes</a> in the <i>Amazon EC2 User Guide</i>.
    /// </para><para>
    /// We don't charge for instance usage or data transfer fees when an instance is stopped.
    /// However, the root volume and any data volumes remain and continue to persist your
    /// data, and you're charged for volume usage. Every time you start your instance, Amazon
    /// EC2 charges a one-minute minimum for instance usage, followed by per-second billing.
    /// </para><para>
    /// You can't stop or hibernate instance store-backed instances.
    /// </para>
    /// </summary>
    [Cmdlet("Stop", "EC2Instance", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.InstanceStateChange")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) StopInstances API operation.", Operation = new[] {"StopInstances"}, SelectReturnType = typeof(Amazon.EC2.Model.StopInstancesResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.InstanceStateChange or Amazon.EC2.Model.StopInstancesResponse",
        "This cmdlet returns a collection of Amazon.EC2.Model.InstanceStateChange objects.",
        "The service call response (type Amazon.EC2.Model.StopInstancesResponse) can be returned by specifying '-Select *'."
    )]
    public partial class StopEC2InstanceCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Enforce
        /// <summary>
        /// <para>
        /// <para>Forces the instance to stop. The instance will first attempt a graceful shutdown,
        /// which includes flushing file system caches and metadata. If the graceful shutdown
        /// fails to complete within the timeout period, the instance shuts down forcibly without
        /// flushing the file system caches and metadata.</para><para>After using this option, you must perform file system check and repair procedures.
        /// This option is not recommended for Windows instances. For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/TroubleshootingInstancesStopping.html">Troubleshoot
        /// Amazon EC2 instance stop issues</a> in the <i>Amazon EC2 User Guide</i>.</para><para>Default: <c>false</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Enforce { get; set; }
        #endregion
        
        #region Parameter Hibernate
        /// <summary>
        /// <para>
        /// <para>Hibernates the instance if the instance was enabled for hibernation at launch. If
        /// the instance cannot hibernate successfully, a normal shutdown occurs. For more information,
        /// see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/Hibernate.html">Hibernate
        /// your instance</a> in the <i>Amazon EC2 User Guide</i>.</para><para> Default: <c>false</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Hibernate { get; set; }
        #endregion
        
        #region Parameter InstanceId
        /// <summary>
        /// <para>
        /// <para>The IDs of the instances.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("InstanceIds")]
        public object[] InstanceId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'StoppingInstances'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.StopInstancesResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.StopInstancesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "StoppingInstances";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the InstanceId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^InstanceId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^InstanceId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.InstanceId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Stop-EC2Instance (StopInstances)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.StopInstancesResponse, StopEC2InstanceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.InstanceId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Enforce = this.Enforce;
            context.Hibernate = this.Hibernate;
            if (this.InstanceId != null)
            {
                context.InstanceId = AmazonEC2Helper.InstanceParamToIDs(this.InstanceId);
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
            var request = new Amazon.EC2.Model.StopInstancesRequest();
            
            if (cmdletContext.Enforce != null)
            {
                request.Force = cmdletContext.Enforce.Value;
            }
            if (cmdletContext.Hibernate != null)
            {
                request.Hibernate = cmdletContext.Hibernate.Value;
            }
            if (cmdletContext.InstanceId != null)
            {
                request.InstanceIds = cmdletContext.InstanceId;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                object pipelineOutput = null;
                pipelineOutput = cmdletContext.Select(response, this);
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response
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
        
        private Amazon.EC2.Model.StopInstancesResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.StopInstancesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "StopInstances");
            try
            {
                #if DESKTOP
                return client.StopInstances(request);
                #elif CORECLR
                return client.StopInstancesAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? Enforce { get; set; }
            public System.Boolean? Hibernate { get; set; }
            public List<System.String> InstanceId { get; set; }
            public System.Func<Amazon.EC2.Model.StopInstancesResponse, StopEC2InstanceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.StoppingInstances;
        }
        
    }
}
