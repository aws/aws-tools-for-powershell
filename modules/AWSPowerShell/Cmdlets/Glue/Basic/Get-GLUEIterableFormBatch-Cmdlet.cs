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
using Amazon.Glue;
using Amazon.Glue.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.GLUE
{
    /// <summary>
    /// Retrieves multiple items from an iterable form on an asset in Glue Data Catalog in
    /// a single request.
    /// </summary>
    [Cmdlet("Get", "GLUEIterableFormBatch")]
    [OutputType("Amazon.Glue.Model.BatchGetIterableFormsResponse")]
    [AWSCmdlet("Calls the AWS Glue BatchGetIterableForms API operation.", Operation = new[] {"BatchGetIterableForms"}, SelectReturnType = typeof(Amazon.Glue.Model.BatchGetIterableFormsResponse))]
    [AWSCmdletOutput("Amazon.Glue.Model.BatchGetIterableFormsResponse",
        "This cmdlet returns an Amazon.Glue.Model.BatchGetIterableFormsResponse object containing multiple properties."
    )]
    public partial class GetGLUEIterableFormBatchCmdlet : AmazonGlueClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AssetIdentifier
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the asset.</para>
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
        public System.String AssetIdentifier { get; set; }
        #endregion
        
        #region Parameter ItemIdentifier
        /// <summary>
        /// <para>
        /// <para>The list of item identifiers to retrieve. Each identifier can be an item ID or item
        /// name.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
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
        [Alias("ItemIdentifiers")]
        public System.String[] ItemIdentifier { get; set; }
        #endregion
        
        #region Parameter IterableFormName
        /// <summary>
        /// <para>
        /// <para>The name of the iterable form to retrieve items from.</para>
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
        public System.String IterableFormName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Glue.Model.BatchGetIterableFormsResponse).
        /// Specifying the name of a property of type Amazon.Glue.Model.BatchGetIterableFormsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
                context.Select = CreateSelectDelegate<Amazon.Glue.Model.BatchGetIterableFormsResponse, GetGLUEIterableFormBatchCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AssetIdentifier = this.AssetIdentifier;
            #if MODULAR
            if (this.AssetIdentifier == null && ParameterWasBound(nameof(this.AssetIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter AssetIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.ItemIdentifier != null)
            {
                context.ItemIdentifier = new List<System.String>(this.ItemIdentifier);
            }
            #if MODULAR
            if (this.ItemIdentifier == null && ParameterWasBound(nameof(this.ItemIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter ItemIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.IterableFormName = this.IterableFormName;
            #if MODULAR
            if (this.IterableFormName == null && ParameterWasBound(nameof(this.IterableFormName)))
            {
                WriteWarning("You are passing $null as a value for parameter IterableFormName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Glue.Model.BatchGetIterableFormsRequest();
            
            if (cmdletContext.AssetIdentifier != null)
            {
                request.AssetIdentifier = cmdletContext.AssetIdentifier;
            }
            if (cmdletContext.ItemIdentifier != null)
            {
                request.ItemIdentifiers = cmdletContext.ItemIdentifier;
            }
            if (cmdletContext.IterableFormName != null)
            {
                request.IterableFormName = cmdletContext.IterableFormName;
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
        
        private Amazon.Glue.Model.BatchGetIterableFormsResponse CallAWSServiceOperation(IAmazonGlue client, Amazon.Glue.Model.BatchGetIterableFormsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Glue", "BatchGetIterableForms");
            try
            {
                return client.BatchGetIterableFormsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AssetIdentifier { get; set; }
            public List<System.String> ItemIdentifier { get; set; }
            public System.String IterableFormName { get; set; }
            public System.Func<Amazon.Glue.Model.BatchGetIterableFormsResponse, GetGLUEIterableFormBatchCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
