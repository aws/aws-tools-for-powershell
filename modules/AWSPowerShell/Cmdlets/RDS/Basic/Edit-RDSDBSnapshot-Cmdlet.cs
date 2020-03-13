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
using Amazon.RDS;
using Amazon.RDS.Model;

namespace Amazon.PowerShell.Cmdlets.RDS
{
    /// <summary>
    /// Updates a manual DB snapshot with a new engine version. The snapshot can be encrypted
    /// or unencrypted, but not shared or public. 
    /// 
    ///  
    /// <para>
    /// Amazon RDS supports upgrading DB snapshots for MySQL, Oracle, and PostgreSQL. 
    /// </para>
    /// </summary>
    [Cmdlet("Edit", "RDSDBSnapshot", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.RDS.Model.DBSnapshot")]
    [AWSCmdlet("Calls the Amazon Relational Database Service ModifyDBSnapshot API operation.", Operation = new[] {"ModifyDBSnapshot"}, SelectReturnType = typeof(Amazon.RDS.Model.ModifyDBSnapshotResponse))]
    [AWSCmdletOutput("Amazon.RDS.Model.DBSnapshot or Amazon.RDS.Model.ModifyDBSnapshotResponse",
        "This cmdlet returns an Amazon.RDS.Model.DBSnapshot object.",
        "The service call response (type Amazon.RDS.Model.ModifyDBSnapshotResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class EditRDSDBSnapshotCmdlet : AmazonRDSClientCmdlet, IExecutor
    {
        
        #region Parameter DBSnapshotIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier of the DB snapshot to modify.</para>
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
        public System.String DBSnapshotIdentifier { get; set; }
        #endregion
        
        #region Parameter EngineVersion
        /// <summary>
        /// <para>
        /// <para>The engine version to upgrade the DB snapshot to. </para><para>The following are the database engines and engine versions that are available when
        /// you upgrade a DB snapshot. </para><para><b>MySQL</b></para><ul><li><para><code>5.5.46</code> (supported for 5.1 DB snapshots)</para></li></ul><para><b>Oracle</b></para><ul><li><para><code>12.1.0.2.v8</code> (supported for 12.1.0.1 DB snapshots)</para></li><li><para><code>11.2.0.4.v12</code> (supported for 11.2.0.2 DB snapshots)</para></li><li><para><code>11.2.0.4.v11</code> (supported for 11.2.0.3 DB snapshots)</para></li></ul><para><b>PostgreSQL</b></para><para>For the list of engine versions that are available for upgrading a DB snapshot, see
        /// <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/USER_UpgradeDBInstance.PostgreSQL.html#USER_UpgradeDBInstance.PostgreSQL.MajorVersion">
        /// Upgrading the PostgreSQL DB Engine for Amazon RDS</a>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EngineVersion { get; set; }
        #endregion
        
        #region Parameter OptionGroupName
        /// <summary>
        /// <para>
        /// <para>The option group to identify with the upgraded DB snapshot. </para><para>You can specify this parameter when you upgrade an Oracle DB snapshot. The same option
        /// group considerations apply when upgrading a DB snapshot as when upgrading a DB instance.
        /// For more information, see <a href="http://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/USER_UpgradeDBInstance.Oracle.html#USER_UpgradeDBInstance.Oracle.OGPG.OG">Option
        /// Group Considerations</a> in the <i>Amazon RDS User Guide.</i></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OptionGroupName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DBSnapshot'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.RDS.Model.ModifyDBSnapshotResponse).
        /// Specifying the name of a property of type Amazon.RDS.Model.ModifyDBSnapshotResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DBSnapshot";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the DBSnapshotIdentifier parameter.
        /// The -PassThru parameter is deprecated, use -Select '^DBSnapshotIdentifier' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^DBSnapshotIdentifier' instead. This parameter will be removed in a future version.")]
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DBSnapshotIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-RDSDBSnapshot (ModifyDBSnapshot)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.RDS.Model.ModifyDBSnapshotResponse, EditRDSDBSnapshotCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.DBSnapshotIdentifier;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.DBSnapshotIdentifier = this.DBSnapshotIdentifier;
            #if MODULAR
            if (this.DBSnapshotIdentifier == null && ParameterWasBound(nameof(this.DBSnapshotIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter DBSnapshotIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EngineVersion = this.EngineVersion;
            context.OptionGroupName = this.OptionGroupName;
            
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
            var request = new Amazon.RDS.Model.ModifyDBSnapshotRequest();
            
            if (cmdletContext.DBSnapshotIdentifier != null)
            {
                request.DBSnapshotIdentifier = cmdletContext.DBSnapshotIdentifier;
            }
            if (cmdletContext.EngineVersion != null)
            {
                request.EngineVersion = cmdletContext.EngineVersion;
            }
            if (cmdletContext.OptionGroupName != null)
            {
                request.OptionGroupName = cmdletContext.OptionGroupName;
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
        
        private Amazon.RDS.Model.ModifyDBSnapshotResponse CallAWSServiceOperation(IAmazonRDS client, Amazon.RDS.Model.ModifyDBSnapshotRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Relational Database Service", "ModifyDBSnapshot");
            try
            {
                #if DESKTOP
                return client.ModifyDBSnapshot(request);
                #elif CORECLR
                return client.ModifyDBSnapshotAsync(request).GetAwaiter().GetResult();
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
            public System.String DBSnapshotIdentifier { get; set; }
            public System.String EngineVersion { get; set; }
            public System.String OptionGroupName { get; set; }
            public System.Func<Amazon.RDS.Model.ModifyDBSnapshotResponse, EditRDSDBSnapshotCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DBSnapshot;
        }
        
    }
}
