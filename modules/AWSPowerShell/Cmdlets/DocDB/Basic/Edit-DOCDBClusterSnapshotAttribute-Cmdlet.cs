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
using Amazon.DocDB;
using Amazon.DocDB.Model;

namespace Amazon.PowerShell.Cmdlets.DOC
{
    /// <summary>
    /// Adds an attribute and values to, or removes an attribute and values from, a manual
    /// DB cluster snapshot.
    /// 
    ///  
    /// <para>
    /// To share a manual cluster snapshot with other AWS accounts, specify <code>restore</code>
    /// as the <code>AttributeName</code>, and use the <code>ValuesToAdd</code> parameter
    /// to add a list of IDs of the AWS accounts that are authorized to restore the manual
    /// cluster snapshot. Use the value <code>all</code> to make the manual cluster snapshot
    /// public, which means that it can be copied or restored by all AWS accounts. Do not
    /// add the <code>all</code> value for any manual DB cluster snapshots that contain private
    /// information that you don't want available to all AWS accounts. If a manual cluster
    /// snapshot is encrypted, it can be shared, but only by specifying a list of authorized
    /// AWS account IDs for the <code>ValuesToAdd</code> parameter. You can't use <code>all</code>
    /// as a value for that parameter in this case.
    /// </para>
    /// </summary>
    [Cmdlet("Edit", "DOCDBClusterSnapshotAttribute", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DocDB.Model.DBClusterSnapshotAttributesResult")]
    [AWSCmdlet("Calls the Amazon DocumentDB (with MongoDB compatibility) ModifyDBClusterSnapshotAttribute API operation.", Operation = new[] {"ModifyDBClusterSnapshotAttribute"}, SelectReturnType = typeof(Amazon.DocDB.Model.ModifyDBClusterSnapshotAttributeResponse))]
    [AWSCmdletOutput("Amazon.DocDB.Model.DBClusterSnapshotAttributesResult or Amazon.DocDB.Model.ModifyDBClusterSnapshotAttributeResponse",
        "This cmdlet returns an Amazon.DocDB.Model.DBClusterSnapshotAttributesResult object.",
        "The service call response (type Amazon.DocDB.Model.ModifyDBClusterSnapshotAttributeResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class EditDOCDBClusterSnapshotAttributeCmdlet : AmazonDocDBClientCmdlet, IExecutor
    {
        
        #region Parameter AttributeName
        /// <summary>
        /// <para>
        /// <para>The name of the cluster snapshot attribute to modify.</para><para>To manage authorization for other AWS accounts to copy or restore a manual cluster
        /// snapshot, set this value to <code>restore</code>.</para>
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
        public System.String AttributeName { get; set; }
        #endregion
        
        #region Parameter DBClusterSnapshotIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier for the cluster snapshot to modify the attributes for.</para>
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
        public System.String DBClusterSnapshotIdentifier { get; set; }
        #endregion
        
        #region Parameter ValuesToAdd
        /// <summary>
        /// <para>
        /// <para>A list of cluster snapshot attributes to add to the attribute specified by <code>AttributeName</code>.</para><para>To authorize other AWS accounts to copy or restore a manual cluster snapshot, set
        /// this list to include one or more AWS account IDs. To make the manual cluster snapshot
        /// restorable by any AWS account, set it to <code>all</code>. Do not add the <code>all</code>
        /// value for any manual cluster snapshots that contain private information that you don't
        /// want to be available to all AWS accounts.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] ValuesToAdd { get; set; }
        #endregion
        
        #region Parameter ValuesToRemove
        /// <summary>
        /// <para>
        /// <para>A list of cluster snapshot attributes to remove from the attribute specified by <code>AttributeName</code>.</para><para>To remove authorization for other AWS accounts to copy or restore a manual cluster
        /// snapshot, set this list to include one or more AWS account identifiers. To remove
        /// authorization for any AWS account to copy or restore the cluster snapshot, set it
        /// to <code>all</code> . If you specify <code>all</code>, an AWS account whose account
        /// ID is explicitly added to the <code>restore</code> attribute can still copy or restore
        /// a manual cluster snapshot.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] ValuesToRemove { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DBClusterSnapshotAttributesResult'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DocDB.Model.ModifyDBClusterSnapshotAttributeResponse).
        /// Specifying the name of a property of type Amazon.DocDB.Model.ModifyDBClusterSnapshotAttributeResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DBClusterSnapshotAttributesResult";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the AttributeName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^AttributeName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^AttributeName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AttributeName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-DOCDBClusterSnapshotAttribute (ModifyDBClusterSnapshotAttribute)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DocDB.Model.ModifyDBClusterSnapshotAttributeResponse, EditDOCDBClusterSnapshotAttributeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.AttributeName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AttributeName = this.AttributeName;
            #if MODULAR
            if (this.AttributeName == null && ParameterWasBound(nameof(this.AttributeName)))
            {
                WriteWarning("You are passing $null as a value for parameter AttributeName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DBClusterSnapshotIdentifier = this.DBClusterSnapshotIdentifier;
            #if MODULAR
            if (this.DBClusterSnapshotIdentifier == null && ParameterWasBound(nameof(this.DBClusterSnapshotIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter DBClusterSnapshotIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.ValuesToAdd != null)
            {
                context.ValuesToAdd = new List<System.String>(this.ValuesToAdd);
            }
            if (this.ValuesToRemove != null)
            {
                context.ValuesToRemove = new List<System.String>(this.ValuesToRemove);
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
            var request = new Amazon.DocDB.Model.ModifyDBClusterSnapshotAttributeRequest();
            
            if (cmdletContext.AttributeName != null)
            {
                request.AttributeName = cmdletContext.AttributeName;
            }
            if (cmdletContext.DBClusterSnapshotIdentifier != null)
            {
                request.DBClusterSnapshotIdentifier = cmdletContext.DBClusterSnapshotIdentifier;
            }
            if (cmdletContext.ValuesToAdd != null)
            {
                request.ValuesToAdd = cmdletContext.ValuesToAdd;
            }
            if (cmdletContext.ValuesToRemove != null)
            {
                request.ValuesToRemove = cmdletContext.ValuesToRemove;
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
        
        private Amazon.DocDB.Model.ModifyDBClusterSnapshotAttributeResponse CallAWSServiceOperation(IAmazonDocDB client, Amazon.DocDB.Model.ModifyDBClusterSnapshotAttributeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon DocumentDB (with MongoDB compatibility)", "ModifyDBClusterSnapshotAttribute");
            try
            {
                #if DESKTOP
                return client.ModifyDBClusterSnapshotAttribute(request);
                #elif CORECLR
                return client.ModifyDBClusterSnapshotAttributeAsync(request).GetAwaiter().GetResult();
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
            public System.String AttributeName { get; set; }
            public System.String DBClusterSnapshotIdentifier { get; set; }
            public List<System.String> ValuesToAdd { get; set; }
            public List<System.String> ValuesToRemove { get; set; }
            public System.Func<Amazon.DocDB.Model.ModifyDBClusterSnapshotAttributeResponse, EditDOCDBClusterSnapshotAttributeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DBClusterSnapshotAttributesResult;
        }
        
    }
}
