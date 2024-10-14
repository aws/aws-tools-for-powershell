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
    /// Copies a manual snapshot of an instance or disk as another manual snapshot, or copies
    /// an automatic snapshot of an instance or disk as a manual snapshot. This operation
    /// can also be used to copy a manual or automatic snapshot of an instance or a disk from
    /// one Amazon Web Services Region to another in Amazon Lightsail.
    /// 
    ///  
    /// <para>
    /// When copying a <i>manual snapshot</i>, be sure to define the <c>source region</c>,
    /// <c>source snapshot name</c>, and <c>target snapshot name</c> parameters.
    /// </para><para>
    /// When copying an <i>automatic snapshot</i>, be sure to define the <c>source region</c>,
    /// <c>source resource name</c>, <c>target snapshot name</c>, and either the <c>restore
    /// date</c> or the <c>use latest restorable auto snapshot</c> parameters.
    /// </para>
    /// </summary>
    [Cmdlet("Copy", "LSSnapshot", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Lightsail.Model.Operation")]
    [AWSCmdlet("Calls the Amazon Lightsail CopySnapshot API operation.", Operation = new[] {"CopySnapshot"}, SelectReturnType = typeof(Amazon.Lightsail.Model.CopySnapshotResponse))]
    [AWSCmdletOutput("Amazon.Lightsail.Model.Operation or Amazon.Lightsail.Model.CopySnapshotResponse",
        "This cmdlet returns a collection of Amazon.Lightsail.Model.Operation objects.",
        "The service call response (type Amazon.Lightsail.Model.CopySnapshotResponse) can be returned by specifying '-Select *'."
    )]
    public partial class CopyLSSnapshotCmdlet : AmazonLightsailClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter RestoreDate
        /// <summary>
        /// <para>
        /// <para>The date of the source automatic snapshot to copy. Use the <c>get auto snapshots</c>
        /// operation to identify the dates of the available automatic snapshots.</para><para>Constraints:</para><ul><li><para>Must be specified in <c>YYYY-MM-DD</c> format.</para></li><li><para>This parameter cannot be defined together with the <c>use latest restorable auto snapshot</c>
        /// parameter. The <c>restore date</c> and <c>use latest restorable auto snapshot</c>
        /// parameters are mutually exclusive.</para></li><li><para>Define this parameter only when copying an automatic snapshot as a manual snapshot.
        /// For more information, see the <a href="https://lightsail.aws.amazon.com/ls/docs/en_us/articles/amazon-lightsail-keeping-automatic-snapshots">Amazon
        /// Lightsail Developer Guide</a>.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RestoreDate { get; set; }
        #endregion
        
        #region Parameter SourceRegion
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services Region where the source manual or automatic snapshot is located.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Lightsail.RegionName")]
        public Amazon.Lightsail.RegionName SourceRegion { get; set; }
        #endregion
        
        #region Parameter SourceResourceName
        /// <summary>
        /// <para>
        /// <para>The name of the source instance or disk from which the source automatic snapshot was
        /// created.</para><para>Constraint:</para><ul><li><para>Define this parameter only when copying an automatic snapshot as a manual snapshot.
        /// For more information, see the <a href="https://lightsail.aws.amazon.com/ls/docs/en_us/articles/amazon-lightsail-keeping-automatic-snapshots">Amazon
        /// Lightsail Developer Guide</a>.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SourceResourceName { get; set; }
        #endregion
        
        #region Parameter SourceSnapshotName
        /// <summary>
        /// <para>
        /// <para>The name of the source manual snapshot to copy.</para><para>Constraint:</para><ul><li><para>Define this parameter only when copying a manual snapshot as another manual snapshot.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SourceSnapshotName { get; set; }
        #endregion
        
        #region Parameter TargetSnapshotName
        /// <summary>
        /// <para>
        /// <para>The name of the new manual snapshot to be created as a copy.</para>
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
        public System.String TargetSnapshotName { get; set; }
        #endregion
        
        #region Parameter UseLatestRestorableAutoSnapshot
        /// <summary>
        /// <para>
        /// <para>A Boolean value to indicate whether to use the latest available automatic snapshot
        /// of the specified source instance or disk.</para><para>Constraints:</para><ul><li><para>This parameter cannot be defined together with the <c>restore date</c> parameter.
        /// The <c>use latest restorable auto snapshot</c> and <c>restore date</c> parameters
        /// are mutually exclusive.</para></li><li><para>Define this parameter only when copying an automatic snapshot as a manual snapshot.
        /// For more information, see the <a href="https://lightsail.aws.amazon.com/ls/docs/en_us/articles/amazon-lightsail-keeping-automatic-snapshots">Amazon
        /// Lightsail Developer Guide</a>.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? UseLatestRestorableAutoSnapshot { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Operations'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Lightsail.Model.CopySnapshotResponse).
        /// Specifying the name of a property of type Amazon.Lightsail.Model.CopySnapshotResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Operations";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the TargetSnapshotName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^TargetSnapshotName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^TargetSnapshotName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TargetSnapshotName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Copy-LSSnapshot (CopySnapshot)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Lightsail.Model.CopySnapshotResponse, CopyLSSnapshotCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.TargetSnapshotName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.RestoreDate = this.RestoreDate;
            context.SourceRegion = this.SourceRegion;
            #if MODULAR
            if (this.SourceRegion == null && ParameterWasBound(nameof(this.SourceRegion)))
            {
                WriteWarning("You are passing $null as a value for parameter SourceRegion which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SourceResourceName = this.SourceResourceName;
            context.SourceSnapshotName = this.SourceSnapshotName;
            context.TargetSnapshotName = this.TargetSnapshotName;
            #if MODULAR
            if (this.TargetSnapshotName == null && ParameterWasBound(nameof(this.TargetSnapshotName)))
            {
                WriteWarning("You are passing $null as a value for parameter TargetSnapshotName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            var request = new Amazon.Lightsail.Model.CopySnapshotRequest();
            
            if (cmdletContext.RestoreDate != null)
            {
                request.RestoreDate = cmdletContext.RestoreDate;
            }
            if (cmdletContext.SourceRegion != null)
            {
                request.SourceRegion = cmdletContext.SourceRegion;
            }
            if (cmdletContext.SourceResourceName != null)
            {
                request.SourceResourceName = cmdletContext.SourceResourceName;
            }
            if (cmdletContext.SourceSnapshotName != null)
            {
                request.SourceSnapshotName = cmdletContext.SourceSnapshotName;
            }
            if (cmdletContext.TargetSnapshotName != null)
            {
                request.TargetSnapshotName = cmdletContext.TargetSnapshotName;
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
        
        private Amazon.Lightsail.Model.CopySnapshotResponse CallAWSServiceOperation(IAmazonLightsail client, Amazon.Lightsail.Model.CopySnapshotRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Lightsail", "CopySnapshot");
            try
            {
                #if DESKTOP
                return client.CopySnapshot(request);
                #elif CORECLR
                return client.CopySnapshotAsync(request).GetAwaiter().GetResult();
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
            public System.String RestoreDate { get; set; }
            public Amazon.Lightsail.RegionName SourceRegion { get; set; }
            public System.String SourceResourceName { get; set; }
            public System.String SourceSnapshotName { get; set; }
            public System.String TargetSnapshotName { get; set; }
            public System.Boolean? UseLatestRestorableAutoSnapshot { get; set; }
            public System.Func<Amazon.Lightsail.Model.CopySnapshotResponse, CopyLSSnapshotCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Operations;
        }
        
    }
}
