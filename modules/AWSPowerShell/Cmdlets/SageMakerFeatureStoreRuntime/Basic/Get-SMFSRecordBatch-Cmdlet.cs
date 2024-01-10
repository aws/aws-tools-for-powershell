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
    /// Retrieves a batch of <c>Records</c> from a <c>FeatureGroup</c>.
    /// </summary>
    [Cmdlet("Get", "SMFSRecordBatch")]
    [OutputType("Amazon.SageMakerFeatureStoreRuntime.Model.BatchGetRecordResponse")]
    [AWSCmdlet("Calls the Amazon SageMaker Feature Store Runtime BatchGetRecord API operation.", Operation = new[] {"BatchGetRecord"}, SelectReturnType = typeof(Amazon.SageMakerFeatureStoreRuntime.Model.BatchGetRecordResponse))]
    [AWSCmdletOutput("Amazon.SageMakerFeatureStoreRuntime.Model.BatchGetRecordResponse",
        "This cmdlet returns an Amazon.SageMakerFeatureStoreRuntime.Model.BatchGetRecordResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetSMFSRecordBatchCmdlet : AmazonSageMakerFeatureStoreRuntimeClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ExpirationTimeResponse
        /// <summary>
        /// <para>
        /// <para>Parameter to request <c>ExpiresAt</c> in response. If <c>Enabled</c>, <c>BatchGetRecord</c>
        /// will return the value of <c>ExpiresAt</c>, if it is not null. If <c>Disabled</c> and
        /// null, <c>BatchGetRecord</c> will return null.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [AWSConstantClassSource("Amazon.SageMakerFeatureStoreRuntime.ExpirationTimeResponse")]
        public Amazon.SageMakerFeatureStoreRuntime.ExpirationTimeResponse ExpirationTimeResponse { get; set; }
        #endregion
        
        #region Parameter Identifier
        /// <summary>
        /// <para>
        /// <para>A list containing the name or Amazon Resource Name (ARN) of the <c>FeatureGroup</c>,
        /// the list of names of <c>Feature</c>s to be retrieved, and the corresponding <c>RecordIdentifier</c>
        /// values as strings.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("Identifiers")]
        public Amazon.SageMakerFeatureStoreRuntime.Model.BatchGetRecordIdentifier[] Identifier { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMakerFeatureStoreRuntime.Model.BatchGetRecordResponse).
        /// Specifying the name of a property of type Amazon.SageMakerFeatureStoreRuntime.Model.BatchGetRecordResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ExpirationTimeResponse parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ExpirationTimeResponse' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ExpirationTimeResponse' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMakerFeatureStoreRuntime.Model.BatchGetRecordResponse, GetSMFSRecordBatchCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ExpirationTimeResponse;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ExpirationTimeResponse = this.ExpirationTimeResponse;
            if (this.Identifier != null)
            {
                context.Identifier = new List<Amazon.SageMakerFeatureStoreRuntime.Model.BatchGetRecordIdentifier>(this.Identifier);
            }
            #if MODULAR
            if (this.Identifier == null && ParameterWasBound(nameof(this.Identifier)))
            {
                WriteWarning("You are passing $null as a value for parameter Identifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SageMakerFeatureStoreRuntime.Model.BatchGetRecordRequest();
            
            if (cmdletContext.ExpirationTimeResponse != null)
            {
                request.ExpirationTimeResponse = cmdletContext.ExpirationTimeResponse;
            }
            if (cmdletContext.Identifier != null)
            {
                request.Identifiers = cmdletContext.Identifier;
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
        
        private Amazon.SageMakerFeatureStoreRuntime.Model.BatchGetRecordResponse CallAWSServiceOperation(IAmazonSageMakerFeatureStoreRuntime client, Amazon.SageMakerFeatureStoreRuntime.Model.BatchGetRecordRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Feature Store Runtime", "BatchGetRecord");
            try
            {
                #if DESKTOP
                return client.BatchGetRecord(request);
                #elif CORECLR
                return client.BatchGetRecordAsync(request).GetAwaiter().GetResult();
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
            public Amazon.SageMakerFeatureStoreRuntime.ExpirationTimeResponse ExpirationTimeResponse { get; set; }
            public List<Amazon.SageMakerFeatureStoreRuntime.Model.BatchGetRecordIdentifier> Identifier { get; set; }
            public System.Func<Amazon.SageMakerFeatureStoreRuntime.Model.BatchGetRecordResponse, GetSMFSRecordBatchCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
