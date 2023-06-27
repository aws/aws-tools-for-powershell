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
using Amazon.SageMakerFeatureStoreRuntime;
using Amazon.SageMakerFeatureStoreRuntime.Model;

namespace Amazon.PowerShell.Cmdlets.SMFS
{
    /// <summary>
    /// Deletes a <code>Record</code> from a <code>FeatureGroup</code> in the <code>OnlineStore</code>.
    /// Feature Store supports both <code>SoftDelete</code> and <code>HardDelete</code>. For
    /// <code>SoftDelete</code> (default), feature columns are set to <code>null</code> and
    /// the record is no longer retrievable by <code>GetRecord</code> or <code>BatchGetRecord</code>.
    /// For <code>HardDelete</code>, the complete <code>Record</code> is removed from the
    /// <code>OnlineStore</code>. In both cases, Feature Store appends the deleted record
    /// marker to the <code>OfflineStore</code> with feature values set to <code>null</code>,
    /// <code>is_deleted</code> value set to <code>True</code>, and <code>EventTime</code>
    /// set to the delete input <code>EventTime</code>.
    /// 
    ///  
    /// <para>
    /// Note that the <code>EventTime</code> specified in <code>DeleteRecord</code> should
    /// be set later than the <code>EventTime</code> of the existing record in the <code>OnlineStore</code>
    /// for that <code>RecordIdentifer</code>. If it is not, the deletion does not occur:
    /// </para><ul><li><para>
    /// For <code>SoftDelete</code>, the existing (undeleted) record remains in the <code>OnlineStore</code>,
    /// though the delete record marker is still written to the <code>OfflineStore</code>.
    /// </para></li><li><para><code>HardDelete</code> returns <code>EventTime</code>: <code>400 ValidationException</code>
    /// to indicate that the delete operation failed. No delete record marker is written to
    /// the <code>OfflineStore</code>.
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Remove", "SMFSRecord", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon SageMaker Feature Store Runtime DeleteRecord API operation.", Operation = new[] {"DeleteRecord"}, SelectReturnType = typeof(Amazon.SageMakerFeatureStoreRuntime.Model.DeleteRecordResponse))]
    [AWSCmdletOutput("None or Amazon.SageMakerFeatureStoreRuntime.Model.DeleteRecordResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.SageMakerFeatureStoreRuntime.Model.DeleteRecordResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RemoveSMFSRecordCmdlet : AmazonSageMakerFeatureStoreRuntimeClientCmdlet, IExecutor
    {
        
        #region Parameter DeletionMode
        /// <summary>
        /// <para>
        /// <para>The name of the deletion mode for deleting the record. By default, the deletion mode
        /// is set to <code>SoftDelete</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SageMakerFeatureStoreRuntime.DeletionMode")]
        public Amazon.SageMakerFeatureStoreRuntime.DeletionMode DeletionMode { get; set; }
        #endregion
        
        #region Parameter EventTime
        /// <summary>
        /// <para>
        /// <para>Timestamp indicating when the deletion event occurred. <code>EventTime</code> can
        /// be used to query data at a certain point in time.</para>
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
        public System.String EventTime { get; set; }
        #endregion
        
        #region Parameter FeatureGroupName
        /// <summary>
        /// <para>
        /// <para>The name of the feature group to delete the record from. </para>
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
        public System.String FeatureGroupName { get; set; }
        #endregion
        
        #region Parameter RecordIdentifierValueAsString
        /// <summary>
        /// <para>
        /// <para>The value for the <code>RecordIdentifier</code> that uniquely identifies the record,
        /// in string format. </para>
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
        public System.String RecordIdentifierValueAsString { get; set; }
        #endregion
        
        #region Parameter TargetStore
        /// <summary>
        /// <para>
        /// <para>A list of stores from which you're deleting the record. By default, Feature Store
        /// deletes the record from all of the stores that you're using for the <code>FeatureGroup</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetStores")]
        public System.String[] TargetStore { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMakerFeatureStoreRuntime.Model.DeleteRecordResponse).
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.FeatureGroupName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-SMFSRecord (DeleteRecord)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMakerFeatureStoreRuntime.Model.DeleteRecordResponse, RemoveSMFSRecordCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DeletionMode = this.DeletionMode;
            context.EventTime = this.EventTime;
            #if MODULAR
            if (this.EventTime == null && ParameterWasBound(nameof(this.EventTime)))
            {
                WriteWarning("You are passing $null as a value for parameter EventTime which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.FeatureGroupName = this.FeatureGroupName;
            #if MODULAR
            if (this.FeatureGroupName == null && ParameterWasBound(nameof(this.FeatureGroupName)))
            {
                WriteWarning("You are passing $null as a value for parameter FeatureGroupName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RecordIdentifierValueAsString = this.RecordIdentifierValueAsString;
            #if MODULAR
            if (this.RecordIdentifierValueAsString == null && ParameterWasBound(nameof(this.RecordIdentifierValueAsString)))
            {
                WriteWarning("You are passing $null as a value for parameter RecordIdentifierValueAsString which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.TargetStore != null)
            {
                context.TargetStore = new List<System.String>(this.TargetStore);
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
            var request = new Amazon.SageMakerFeatureStoreRuntime.Model.DeleteRecordRequest();
            
            if (cmdletContext.DeletionMode != null)
            {
                request.DeletionMode = cmdletContext.DeletionMode;
            }
            if (cmdletContext.EventTime != null)
            {
                request.EventTime = cmdletContext.EventTime;
            }
            if (cmdletContext.FeatureGroupName != null)
            {
                request.FeatureGroupName = cmdletContext.FeatureGroupName;
            }
            if (cmdletContext.RecordIdentifierValueAsString != null)
            {
                request.RecordIdentifierValueAsString = cmdletContext.RecordIdentifierValueAsString;
            }
            if (cmdletContext.TargetStore != null)
            {
                request.TargetStores = cmdletContext.TargetStore;
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
        
        private Amazon.SageMakerFeatureStoreRuntime.Model.DeleteRecordResponse CallAWSServiceOperation(IAmazonSageMakerFeatureStoreRuntime client, Amazon.SageMakerFeatureStoreRuntime.Model.DeleteRecordRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Feature Store Runtime", "DeleteRecord");
            try
            {
                #if DESKTOP
                return client.DeleteRecord(request);
                #elif CORECLR
                return client.DeleteRecordAsync(request).GetAwaiter().GetResult();
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
            public Amazon.SageMakerFeatureStoreRuntime.DeletionMode DeletionMode { get; set; }
            public System.String EventTime { get; set; }
            public System.String FeatureGroupName { get; set; }
            public System.String RecordIdentifierValueAsString { get; set; }
            public List<System.String> TargetStore { get; set; }
            public System.Func<Amazon.SageMakerFeatureStoreRuntime.Model.DeleteRecordResponse, RemoveSMFSRecordCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
