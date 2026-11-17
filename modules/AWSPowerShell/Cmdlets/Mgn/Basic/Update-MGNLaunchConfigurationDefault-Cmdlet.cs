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
using System.Threading;
using Amazon.Mgn;
using Amazon.Mgn.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.MGN
{
    /// <summary>
    /// Updates the launch configuration defaults of a source server. They apply only to disk
    /// mappings created later in the source server's Amazon Elastic Compute Cloud (Amazon
    /// EC2) launch template, and members you omit keep their current values.
    /// </summary>
    [Cmdlet("Update", "MGNLaunchConfigurationDefault", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Mgn.Model.UpdateLaunchConfigurationDefaultsResponse")]
    [AWSCmdlet("Calls the Application Migration Service UpdateLaunchConfigurationDefaults API operation.", Operation = new[] {"UpdateLaunchConfigurationDefaults"}, SelectReturnType = typeof(Amazon.Mgn.Model.UpdateLaunchConfigurationDefaultsResponse))]
    [AWSCmdletOutput("Amazon.Mgn.Model.UpdateLaunchConfigurationDefaultsResponse",
        "This cmdlet returns an Amazon.Mgn.Model.UpdateLaunchConfigurationDefaultsResponse object containing multiple properties."
    )]
    public partial class UpdateMGNLaunchConfigurationDefaultCmdlet : AmazonMgnClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AccountID
        /// <summary>
        /// <para>
        /// <para>Request to update the launch configuration defaults by Account ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AccountID { get; set; }
        #endregion
        
        #region Parameter LargeVolumeConfiguration_DeleteOnTermination
        /// <summary>
        /// <para>
        /// <para>Specifies whether the volume is deleted when the launched instance terminates.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Mgn.DeleteOnTermination")]
        public Amazon.Mgn.DeleteOnTermination LargeVolumeConfiguration_DeleteOnTermination { get; set; }
        #endregion
        
        #region Parameter SmallVolumeConfiguration_DeleteOnTermination
        /// <summary>
        /// <para>
        /// <para>Specifies whether the volume is deleted when the launched instance terminates.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Mgn.DeleteOnTermination")]
        public Amazon.Mgn.DeleteOnTermination SmallVolumeConfiguration_DeleteOnTermination { get; set; }
        #endregion
        
        #region Parameter LargeVolumeConfiguration_Iops
        /// <summary>
        /// <para>
        /// <para>Provisioned IOPS, for io1, io2 and gp3 volumes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? LargeVolumeConfiguration_Iops { get; set; }
        #endregion
        
        #region Parameter SmallVolumeConfiguration_Iops
        /// <summary>
        /// <para>
        /// <para>Provisioned IOPS, for io1, io2 and gp3 volumes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? SmallVolumeConfiguration_Iops { get; set; }
        #endregion
        
        #region Parameter SmallVolumeMaxSize
        /// <summary>
        /// <para>
        /// <para>Disks up to this size, in GiB, use the small volume configuration, and larger disks
        /// use the large one. <c>0</c> means every disk uses the large one. If you omit it, the
        /// current value is kept.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? SmallVolumeMaxSize { get; set; }
        #endregion
        
        #region Parameter SourceServerID
        /// <summary>
        /// <para>
        /// <para>Request to update the launch configuration defaults by Source Server ID.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String SourceServerID { get; set; }
        #endregion
        
        #region Parameter LargeVolumeConfiguration_Throughput
        /// <summary>
        /// <para>
        /// <para>Throughput in MiB/s, for gp3 volumes only.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? LargeVolumeConfiguration_Throughput { get; set; }
        #endregion
        
        #region Parameter SmallVolumeConfiguration_Throughput
        /// <summary>
        /// <para>
        /// <para>Throughput in MiB/s, for gp3 volumes only.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? SmallVolumeConfiguration_Throughput { get; set; }
        #endregion
        
        #region Parameter LargeVolumeConfiguration_VolumeInitializationRate
        /// <summary>
        /// <para>
        /// <para>Provisioned rate for volume initialization, in MiB/s.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? LargeVolumeConfiguration_VolumeInitializationRate { get; set; }
        #endregion
        
        #region Parameter SmallVolumeConfiguration_VolumeInitializationRate
        /// <summary>
        /// <para>
        /// <para>Provisioned rate for volume initialization, in MiB/s.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? SmallVolumeConfiguration_VolumeInitializationRate { get; set; }
        #endregion
        
        #region Parameter LargeVolumeConfiguration_VolumeType
        /// <summary>
        /// <para>
        /// <para>EBS volume type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Mgn.VolumeType")]
        public Amazon.Mgn.VolumeType LargeVolumeConfiguration_VolumeType { get; set; }
        #endregion
        
        #region Parameter SmallVolumeConfiguration_VolumeType
        /// <summary>
        /// <para>
        /// <para>EBS volume type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Mgn.VolumeType")]
        public Amazon.Mgn.VolumeType SmallVolumeConfiguration_VolumeType { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Mgn.Model.UpdateLaunchConfigurationDefaultsResponse).
        /// Specifying the name of a property of type Amazon.Mgn.Model.UpdateLaunchConfigurationDefaultsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SourceServerID), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-MGNLaunchConfigurationDefault (UpdateLaunchConfigurationDefaults)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Mgn.Model.UpdateLaunchConfigurationDefaultsResponse, UpdateMGNLaunchConfigurationDefaultCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AccountID = this.AccountID;
            context.LargeVolumeConfiguration_DeleteOnTermination = this.LargeVolumeConfiguration_DeleteOnTermination;
            context.LargeVolumeConfiguration_Iops = this.LargeVolumeConfiguration_Iops;
            context.LargeVolumeConfiguration_Throughput = this.LargeVolumeConfiguration_Throughput;
            context.LargeVolumeConfiguration_VolumeInitializationRate = this.LargeVolumeConfiguration_VolumeInitializationRate;
            context.LargeVolumeConfiguration_VolumeType = this.LargeVolumeConfiguration_VolumeType;
            context.SmallVolumeConfiguration_DeleteOnTermination = this.SmallVolumeConfiguration_DeleteOnTermination;
            context.SmallVolumeConfiguration_Iops = this.SmallVolumeConfiguration_Iops;
            context.SmallVolumeConfiguration_Throughput = this.SmallVolumeConfiguration_Throughput;
            context.SmallVolumeConfiguration_VolumeInitializationRate = this.SmallVolumeConfiguration_VolumeInitializationRate;
            context.SmallVolumeConfiguration_VolumeType = this.SmallVolumeConfiguration_VolumeType;
            context.SmallVolumeMaxSize = this.SmallVolumeMaxSize;
            context.SourceServerID = this.SourceServerID;
            #if MODULAR
            if (this.SourceServerID == null && ParameterWasBound(nameof(this.SourceServerID)))
            {
                WriteWarning("You are passing $null as a value for parameter SourceServerID which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var request = new Amazon.Mgn.Model.UpdateLaunchConfigurationDefaultsRequest();
            
            if (cmdletContext.AccountID != null)
            {
                request.AccountID = cmdletContext.AccountID;
            }
            
             // populate LargeVolumeConfiguration
            var requestLargeVolumeConfigurationIsNull = true;
            request.LargeVolumeConfiguration = new Amazon.Mgn.Model.SourceServerVolumeConfiguration();
            Amazon.Mgn.DeleteOnTermination requestLargeVolumeConfiguration_largeVolumeConfiguration_DeleteOnTermination = null;
            if (cmdletContext.LargeVolumeConfiguration_DeleteOnTermination != null)
            {
                requestLargeVolumeConfiguration_largeVolumeConfiguration_DeleteOnTermination = cmdletContext.LargeVolumeConfiguration_DeleteOnTermination;
            }
            if (requestLargeVolumeConfiguration_largeVolumeConfiguration_DeleteOnTermination != null)
            {
                request.LargeVolumeConfiguration.DeleteOnTermination = requestLargeVolumeConfiguration_largeVolumeConfiguration_DeleteOnTermination;
                requestLargeVolumeConfigurationIsNull = false;
            }
            System.Int64? requestLargeVolumeConfiguration_largeVolumeConfiguration_Iops = null;
            if (cmdletContext.LargeVolumeConfiguration_Iops != null)
            {
                requestLargeVolumeConfiguration_largeVolumeConfiguration_Iops = cmdletContext.LargeVolumeConfiguration_Iops.Value;
            }
            if (requestLargeVolumeConfiguration_largeVolumeConfiguration_Iops != null)
            {
                request.LargeVolumeConfiguration.Iops = requestLargeVolumeConfiguration_largeVolumeConfiguration_Iops.Value;
                requestLargeVolumeConfigurationIsNull = false;
            }
            System.Int64? requestLargeVolumeConfiguration_largeVolumeConfiguration_Throughput = null;
            if (cmdletContext.LargeVolumeConfiguration_Throughput != null)
            {
                requestLargeVolumeConfiguration_largeVolumeConfiguration_Throughput = cmdletContext.LargeVolumeConfiguration_Throughput.Value;
            }
            if (requestLargeVolumeConfiguration_largeVolumeConfiguration_Throughput != null)
            {
                request.LargeVolumeConfiguration.Throughput = requestLargeVolumeConfiguration_largeVolumeConfiguration_Throughput.Value;
                requestLargeVolumeConfigurationIsNull = false;
            }
            System.Int64? requestLargeVolumeConfiguration_largeVolumeConfiguration_VolumeInitializationRate = null;
            if (cmdletContext.LargeVolumeConfiguration_VolumeInitializationRate != null)
            {
                requestLargeVolumeConfiguration_largeVolumeConfiguration_VolumeInitializationRate = cmdletContext.LargeVolumeConfiguration_VolumeInitializationRate.Value;
            }
            if (requestLargeVolumeConfiguration_largeVolumeConfiguration_VolumeInitializationRate != null)
            {
                request.LargeVolumeConfiguration.VolumeInitializationRate = requestLargeVolumeConfiguration_largeVolumeConfiguration_VolumeInitializationRate.Value;
                requestLargeVolumeConfigurationIsNull = false;
            }
            Amazon.Mgn.VolumeType requestLargeVolumeConfiguration_largeVolumeConfiguration_VolumeType = null;
            if (cmdletContext.LargeVolumeConfiguration_VolumeType != null)
            {
                requestLargeVolumeConfiguration_largeVolumeConfiguration_VolumeType = cmdletContext.LargeVolumeConfiguration_VolumeType;
            }
            if (requestLargeVolumeConfiguration_largeVolumeConfiguration_VolumeType != null)
            {
                request.LargeVolumeConfiguration.VolumeType = requestLargeVolumeConfiguration_largeVolumeConfiguration_VolumeType;
                requestLargeVolumeConfigurationIsNull = false;
            }
             // determine if request.LargeVolumeConfiguration should be set to null
            if (requestLargeVolumeConfigurationIsNull)
            {
                request.LargeVolumeConfiguration = null;
            }
            
             // populate SmallVolumeConfiguration
            var requestSmallVolumeConfigurationIsNull = true;
            request.SmallVolumeConfiguration = new Amazon.Mgn.Model.SourceServerVolumeConfiguration();
            Amazon.Mgn.DeleteOnTermination requestSmallVolumeConfiguration_smallVolumeConfiguration_DeleteOnTermination = null;
            if (cmdletContext.SmallVolumeConfiguration_DeleteOnTermination != null)
            {
                requestSmallVolumeConfiguration_smallVolumeConfiguration_DeleteOnTermination = cmdletContext.SmallVolumeConfiguration_DeleteOnTermination;
            }
            if (requestSmallVolumeConfiguration_smallVolumeConfiguration_DeleteOnTermination != null)
            {
                request.SmallVolumeConfiguration.DeleteOnTermination = requestSmallVolumeConfiguration_smallVolumeConfiguration_DeleteOnTermination;
                requestSmallVolumeConfigurationIsNull = false;
            }
            System.Int64? requestSmallVolumeConfiguration_smallVolumeConfiguration_Iops = null;
            if (cmdletContext.SmallVolumeConfiguration_Iops != null)
            {
                requestSmallVolumeConfiguration_smallVolumeConfiguration_Iops = cmdletContext.SmallVolumeConfiguration_Iops.Value;
            }
            if (requestSmallVolumeConfiguration_smallVolumeConfiguration_Iops != null)
            {
                request.SmallVolumeConfiguration.Iops = requestSmallVolumeConfiguration_smallVolumeConfiguration_Iops.Value;
                requestSmallVolumeConfigurationIsNull = false;
            }
            System.Int64? requestSmallVolumeConfiguration_smallVolumeConfiguration_Throughput = null;
            if (cmdletContext.SmallVolumeConfiguration_Throughput != null)
            {
                requestSmallVolumeConfiguration_smallVolumeConfiguration_Throughput = cmdletContext.SmallVolumeConfiguration_Throughput.Value;
            }
            if (requestSmallVolumeConfiguration_smallVolumeConfiguration_Throughput != null)
            {
                request.SmallVolumeConfiguration.Throughput = requestSmallVolumeConfiguration_smallVolumeConfiguration_Throughput.Value;
                requestSmallVolumeConfigurationIsNull = false;
            }
            System.Int64? requestSmallVolumeConfiguration_smallVolumeConfiguration_VolumeInitializationRate = null;
            if (cmdletContext.SmallVolumeConfiguration_VolumeInitializationRate != null)
            {
                requestSmallVolumeConfiguration_smallVolumeConfiguration_VolumeInitializationRate = cmdletContext.SmallVolumeConfiguration_VolumeInitializationRate.Value;
            }
            if (requestSmallVolumeConfiguration_smallVolumeConfiguration_VolumeInitializationRate != null)
            {
                request.SmallVolumeConfiguration.VolumeInitializationRate = requestSmallVolumeConfiguration_smallVolumeConfiguration_VolumeInitializationRate.Value;
                requestSmallVolumeConfigurationIsNull = false;
            }
            Amazon.Mgn.VolumeType requestSmallVolumeConfiguration_smallVolumeConfiguration_VolumeType = null;
            if (cmdletContext.SmallVolumeConfiguration_VolumeType != null)
            {
                requestSmallVolumeConfiguration_smallVolumeConfiguration_VolumeType = cmdletContext.SmallVolumeConfiguration_VolumeType;
            }
            if (requestSmallVolumeConfiguration_smallVolumeConfiguration_VolumeType != null)
            {
                request.SmallVolumeConfiguration.VolumeType = requestSmallVolumeConfiguration_smallVolumeConfiguration_VolumeType;
                requestSmallVolumeConfigurationIsNull = false;
            }
             // determine if request.SmallVolumeConfiguration should be set to null
            if (requestSmallVolumeConfigurationIsNull)
            {
                request.SmallVolumeConfiguration = null;
            }
            if (cmdletContext.SmallVolumeMaxSize != null)
            {
                request.SmallVolumeMaxSize = cmdletContext.SmallVolumeMaxSize.Value;
            }
            if (cmdletContext.SourceServerID != null)
            {
                request.SourceServerID = cmdletContext.SourceServerID;
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
        
        private Amazon.Mgn.Model.UpdateLaunchConfigurationDefaultsResponse CallAWSServiceOperation(IAmazonMgn client, Amazon.Mgn.Model.UpdateLaunchConfigurationDefaultsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Application Migration Service", "UpdateLaunchConfigurationDefaults");
            try
            {
                return client.UpdateLaunchConfigurationDefaultsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AccountID { get; set; }
            public Amazon.Mgn.DeleteOnTermination LargeVolumeConfiguration_DeleteOnTermination { get; set; }
            public System.Int64? LargeVolumeConfiguration_Iops { get; set; }
            public System.Int64? LargeVolumeConfiguration_Throughput { get; set; }
            public System.Int64? LargeVolumeConfiguration_VolumeInitializationRate { get; set; }
            public Amazon.Mgn.VolumeType LargeVolumeConfiguration_VolumeType { get; set; }
            public Amazon.Mgn.DeleteOnTermination SmallVolumeConfiguration_DeleteOnTermination { get; set; }
            public System.Int64? SmallVolumeConfiguration_Iops { get; set; }
            public System.Int64? SmallVolumeConfiguration_Throughput { get; set; }
            public System.Int64? SmallVolumeConfiguration_VolumeInitializationRate { get; set; }
            public Amazon.Mgn.VolumeType SmallVolumeConfiguration_VolumeType { get; set; }
            public System.Int64? SmallVolumeMaxSize { get; set; }
            public System.String SourceServerID { get; set; }
            public System.Func<Amazon.Mgn.Model.UpdateLaunchConfigurationDefaultsResponse, UpdateMGNLaunchConfigurationDefaultCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
