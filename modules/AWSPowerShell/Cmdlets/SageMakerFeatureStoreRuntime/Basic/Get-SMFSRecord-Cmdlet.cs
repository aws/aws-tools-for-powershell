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
using Amazon.SageMakerFeatureStoreRuntime;
using Amazon.SageMakerFeatureStoreRuntime.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.SMFS
{
    /// <summary>
    /// Use for <c>OnlineStore</c> serving from a <c>FeatureStore</c>. Only the latest records
    /// stored in the <c>OnlineStore</c> can be retrieved. If no Record with <c>RecordIdentifierValue</c>
    /// is found, then an empty result is returned.
    /// </summary>
    [Cmdlet("Get", "SMFSRecord")]
    [OutputType("Amazon.SageMakerFeatureStoreRuntime.Model.FeatureValue")]
    [AWSCmdlet("Calls the Amazon SageMaker Feature Store Runtime GetRecord API operation.", Operation = new[] {"GetRecord"}, SelectReturnType = typeof(Amazon.SageMakerFeatureStoreRuntime.Model.GetRecordResponse))]
    [AWSCmdletOutput("Amazon.SageMakerFeatureStoreRuntime.Model.FeatureValue or Amazon.SageMakerFeatureStoreRuntime.Model.GetRecordResponse",
        "This cmdlet returns a collection of Amazon.SageMakerFeatureStoreRuntime.Model.FeatureValue objects.",
        "The service call response (type Amazon.SageMakerFeatureStoreRuntime.Model.GetRecordResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetSMFSRecordCmdlet : AmazonSageMakerFeatureStoreRuntimeClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ExpirationTimeResponse
        /// <summary>
        /// <para>
        /// <para>Parameter to request <c>ExpiresAt</c> in response. If <c>Enabled</c>, <c>GetRecord</c>
        /// will return the value of <c>ExpiresAt</c>, if it is not null. If <c>Disabled</c> and
        /// null, <c>GetRecord</c> will return null.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SageMakerFeatureStoreRuntime.ExpirationTimeResponse")]
        public Amazon.SageMakerFeatureStoreRuntime.ExpirationTimeResponse ExpirationTimeResponse { get; set; }
        #endregion
        
        #region Parameter FeatureGroupName
        /// <summary>
        /// <para>
        /// <para>The name or Amazon Resource Name (ARN) of the feature group from which you want to
        /// retrieve a record.</para>
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
        
        #region Parameter FeatureName
        /// <summary>
        /// <para>
        /// <para>List of names of Features to be retrieved. If not specified, the latest value for
        /// all the Features are returned.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FeatureNames")]
        public System.String[] FeatureName { get; set; }
        #endregion
        
        #region Parameter RecordIdentifierValueAsString
        /// <summary>
        /// <para>
        /// <para>The value that corresponds to <c>RecordIdentifier</c> type and uniquely identifies
        /// the record in the <c>FeatureGroup</c>. </para>
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
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Record'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMakerFeatureStoreRuntime.Model.GetRecordResponse).
        /// Specifying the name of a property of type Amazon.SageMakerFeatureStoreRuntime.Model.GetRecordResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Record";
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMakerFeatureStoreRuntime.Model.GetRecordResponse, GetSMFSRecordCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ExpirationTimeResponse = this.ExpirationTimeResponse;
            context.FeatureGroupName = this.FeatureGroupName;
            #if MODULAR
            if (this.FeatureGroupName == null && ParameterWasBound(nameof(this.FeatureGroupName)))
            {
                WriteWarning("You are passing $null as a value for parameter FeatureGroupName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.FeatureName != null)
            {
                context.FeatureName = new List<System.String>(this.FeatureName);
            }
            context.RecordIdentifierValueAsString = this.RecordIdentifierValueAsString;
            #if MODULAR
            if (this.RecordIdentifierValueAsString == null && ParameterWasBound(nameof(this.RecordIdentifierValueAsString)))
            {
                WriteWarning("You are passing $null as a value for parameter RecordIdentifierValueAsString which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SageMakerFeatureStoreRuntime.Model.GetRecordRequest();
            
            if (cmdletContext.ExpirationTimeResponse != null)
            {
                request.ExpirationTimeResponse = cmdletContext.ExpirationTimeResponse;
            }
            if (cmdletContext.FeatureGroupName != null)
            {
                request.FeatureGroupName = cmdletContext.FeatureGroupName;
            }
            if (cmdletContext.FeatureName != null)
            {
                request.FeatureNames = cmdletContext.FeatureName;
            }
            if (cmdletContext.RecordIdentifierValueAsString != null)
            {
                request.RecordIdentifierValueAsString = cmdletContext.RecordIdentifierValueAsString;
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
        
        private Amazon.SageMakerFeatureStoreRuntime.Model.GetRecordResponse CallAWSServiceOperation(IAmazonSageMakerFeatureStoreRuntime client, Amazon.SageMakerFeatureStoreRuntime.Model.GetRecordRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Feature Store Runtime", "GetRecord");
            try
            {
                return client.GetRecordAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.SageMakerFeatureStoreRuntime.ExpirationTimeResponse ExpirationTimeResponse { get; set; }
            public System.String FeatureGroupName { get; set; }
            public List<System.String> FeatureName { get; set; }
            public System.String RecordIdentifierValueAsString { get; set; }
            public System.Func<Amazon.SageMakerFeatureStoreRuntime.Model.GetRecordResponse, GetSMFSRecordCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Record;
        }
        
    }
}
