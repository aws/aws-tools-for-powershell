/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.Lightsail;
using Amazon.Lightsail.Model;

namespace Amazon.PowerShell.Cmdlets.LS
{
    /// <summary>
    /// Creates a block storage disk from a manual or automatic snapshot of a disk. The resulting
    /// disk can be attached to an Amazon Lightsail instance in the same Availability Zone
    /// (<c>us-east-2a</c>).
    /// 
    ///  
    /// <para>
    /// The <c>create disk from snapshot</c> operation supports tag-based access control via
    /// request tags and resource tags applied to the resource identified by <c>disk snapshot
    /// name</c>. For more information, see the <a href="https://lightsail.aws.amazon.com/ls/docs/en_us/articles/amazon-lightsail-controlling-access-using-tags">Amazon
    /// Lightsail Developer Guide</a>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "LSDiskFromSnapshot", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Lightsail.Model.Operation")]
    [AWSCmdlet("Calls the Amazon Lightsail CreateDiskFromSnapshot API operation.", Operation = new[] {"CreateDiskFromSnapshot"}, SelectReturnType = typeof(Amazon.Lightsail.Model.CreateDiskFromSnapshotResponse))]
    [AWSCmdletOutput("Amazon.Lightsail.Model.Operation or Amazon.Lightsail.Model.CreateDiskFromSnapshotResponse",
        "This cmdlet returns a collection of Amazon.Lightsail.Model.Operation objects.",
        "The service call response (type Amazon.Lightsail.Model.CreateDiskFromSnapshotResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewLSDiskFromSnapshotCmdlet : AmazonLightsailClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AddOn
        /// <summary>
        /// <para>
        /// <para>An array of objects that represent the add-ons to enable for the new disk.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AddOns")]
        public Amazon.Lightsail.Model.AddOnRequest[] AddOn { get; set; }
        #endregion
        
        #region Parameter AvailabilityZone
        /// <summary>
        /// <para>
        /// <para>The Availability Zone where you want to create the disk (<c>us-east-2a</c>). Choose
        /// the same Availability Zone as the Lightsail instance where you want to create the
        /// disk.</para><para>Use the GetRegions operation to list the Availability Zones where Lightsail is currently
        /// available.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String AvailabilityZone { get; set; }
        #endregion
        
        #region Parameter DiskName
        /// <summary>
        /// <para>
        /// <para>The unique Lightsail disk name (<c>my-disk</c>).</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String DiskName { get; set; }
        #endregion
        
        #region Parameter DiskSnapshotName
        /// <summary>
        /// <para>
        /// <para>The name of the disk snapshot (<c>my-snapshot</c>) from which to create the new storage
        /// disk.</para><para>Constraint:</para><ul><li><para>This parameter cannot be defined together with the <c>source disk name</c> parameter.
        /// The <c>disk snapshot name</c> and <c>source disk name</c> parameters are mutually
        /// exclusive.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String DiskSnapshotName { get; set; }
        #endregion
        
        #region Parameter RestoreDate
        /// <summary>
        /// <para>
        /// <para>The date of the automatic snapshot to use for the new disk. Use the <c>get auto snapshots</c>
        /// operation to identify the dates of the available automatic snapshots.</para><para>Constraints:</para><ul><li><para>Must be specified in <c>YYYY-MM-DD</c> format.</para></li><li><para>This parameter cannot be defined together with the <c>use latest restorable auto snapshot</c>
        /// parameter. The <c>restore date</c> and <c>use latest restorable auto snapshot</c>
        /// parameters are mutually exclusive.</para></li><li><para>Define this parameter only when creating a new disk from an automatic snapshot. For
        /// more information, see the <a href="https://lightsail.aws.amazon.com/ls/docs/en_us/articles/amazon-lightsail-configuring-automatic-snapshots">Amazon
        /// Lightsail Developer Guide</a>.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RestoreDate { get; set; }
        #endregion
        
        #region Parameter SizeInGb
        /// <summary>
        /// <para>
        /// <para>The size of the disk in GB (<c>32</c>).</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? SizeInGb { get; set; }
        #endregion
        
        #region Parameter SourceDiskName
        /// <summary>
        /// <para>
        /// <para>The name of the source disk from which the source automatic snapshot was created.</para><para>Constraints:</para><ul><li><para>This parameter cannot be defined together with the <c>disk snapshot name</c> parameter.
        /// The <c>source disk name</c> and <c>disk snapshot name</c> parameters are mutually
        /// exclusive.</para></li><li><para>Define this parameter only when creating a new disk from an automatic snapshot. For
        /// more information, see the <a href="https://lightsail.aws.amazon.com/ls/docs/en_us/articles/amazon-lightsail-configuring-automatic-snapshots">Amazon
        /// Lightsail Developer Guide</a>.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SourceDiskName { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tag keys and optional values to add to the resource during create.</para><para>Use the <c>TagResource</c> action to tag a resource after it's created.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.Lightsail.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter UseLatestRestorableAutoSnapshot
        /// <summary>
        /// <para>
        /// <para>A Boolean value to indicate whether to use the latest available automatic snapshot.</para><para>Constraints:</para><ul><li><para>This parameter cannot be defined together with the <c>restore date</c> parameter.
        /// The <c>use latest restorable auto snapshot</c> and <c>restore date</c> parameters
        /// are mutually exclusive.</para></li><li><para>Define this parameter only when creating a new disk from an automatic snapshot. For
        /// more information, see the <a href="https://lightsail.aws.amazon.com/ls/docs/en_us/articles/amazon-lightsail-configuring-automatic-snapshots">Amazon
        /// Lightsail Developer Guide</a>.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? UseLatestRestorableAutoSnapshot { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Operations'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Lightsail.Model.CreateDiskFromSnapshotResponse).
        /// Specifying the name of a property of type Amazon.Lightsail.Model.CreateDiskFromSnapshotResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Operations";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DiskSnapshotName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-LSDiskFromSnapshot (CreateDiskFromSnapshot)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Lightsail.Model.CreateDiskFromSnapshotResponse, NewLSDiskFromSnapshotCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AddOn != null)
            {
                context.AddOn = new List<Amazon.Lightsail.Model.AddOnRequest>(this.AddOn);
            }
            context.AvailabilityZone = this.AvailabilityZone;
            #if MODULAR
            if (this.AvailabilityZone == null && ParameterWasBound(nameof(this.AvailabilityZone)))
            {
                WriteWarning("You are passing $null as a value for parameter AvailabilityZone which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DiskName = this.DiskName;
            #if MODULAR
            if (this.DiskName == null && ParameterWasBound(nameof(this.DiskName)))
            {
                WriteWarning("You are passing $null as a value for parameter DiskName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DiskSnapshotName = this.DiskSnapshotName;
            context.RestoreDate = this.RestoreDate;
            context.SizeInGb = this.SizeInGb;
            #if MODULAR
            if (this.SizeInGb == null && ParameterWasBound(nameof(this.SizeInGb)))
            {
                WriteWarning("You are passing $null as a value for parameter SizeInGb which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SourceDiskName = this.SourceDiskName;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.Lightsail.Model.Tag>(this.Tag);
            }
            context.UseLatestRestorableAutoSnapshot = this.UseLatestRestorableAutoSnapshot;
            
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
            var request = new Amazon.Lightsail.Model.CreateDiskFromSnapshotRequest();
            
            if (cmdletContext.AddOn != null)
            {
                request.AddOns = cmdletContext.AddOn;
            }
            if (cmdletContext.AvailabilityZone != null)
            {
                request.AvailabilityZone = cmdletContext.AvailabilityZone;
            }
            if (cmdletContext.DiskName != null)
            {
                request.DiskName = cmdletContext.DiskName;
            }
            if (cmdletContext.DiskSnapshotName != null)
            {
                request.DiskSnapshotName = cmdletContext.DiskSnapshotName;
            }
            if (cmdletContext.RestoreDate != null)
            {
                request.RestoreDate = cmdletContext.RestoreDate;
            }
            if (cmdletContext.SizeInGb != null)
            {
                request.SizeInGb = cmdletContext.SizeInGb.Value;
            }
            if (cmdletContext.SourceDiskName != null)
            {
                request.SourceDiskName = cmdletContext.SourceDiskName;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.UseLatestRestorableAutoSnapshot != null)
            {
                request.UseLatestRestorableAutoSnapshot = cmdletContext.UseLatestRestorableAutoSnapshot.Value;
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
        
        private Amazon.Lightsail.Model.CreateDiskFromSnapshotResponse CallAWSServiceOperation(IAmazonLightsail client, Amazon.Lightsail.Model.CreateDiskFromSnapshotRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Lightsail", "CreateDiskFromSnapshot");
            try
            {
                #if DESKTOP
                return client.CreateDiskFromSnapshot(request);
                #elif CORECLR
                return client.CreateDiskFromSnapshotAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.Lightsail.Model.AddOnRequest> AddOn { get; set; }
            public System.String AvailabilityZone { get; set; }
            public System.String DiskName { get; set; }
            public System.String DiskSnapshotName { get; set; }
            public System.String RestoreDate { get; set; }
            public System.Int32? SizeInGb { get; set; }
            public System.String SourceDiskName { get; set; }
            public List<Amazon.Lightsail.Model.Tag> Tag { get; set; }
            public System.Boolean? UseLatestRestorableAutoSnapshot { get; set; }
            public System.Func<Amazon.Lightsail.Model.CreateDiskFromSnapshotResponse, NewLSDiskFromSnapshotCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Operations;
        }
        
    }
}
