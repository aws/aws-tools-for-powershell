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
using Amazon.AppSync;
using Amazon.AppSync.Model;

namespace Amazon.PowerShell.Cmdlets.ASYN
{
    /// <summary>
    /// Retrieves the record of an existing introspection. If the retrieval is successful,
    /// the result of the instrospection will also be returned. If the retrieval fails the
    /// operation, an error message will be returned instead.
    /// </summary>
    [Cmdlet("Get", "ASYNDataSourceIntrospection")]
    [OutputType("Amazon.AppSync.Model.GetDataSourceIntrospectionResponse")]
    [AWSCmdlet("Calls the AWS AppSync GetDataSourceIntrospection API operation.", Operation = new[] {"GetDataSourceIntrospection"}, SelectReturnType = typeof(Amazon.AppSync.Model.GetDataSourceIntrospectionResponse))]
    [AWSCmdletOutput("Amazon.AppSync.Model.GetDataSourceIntrospectionResponse",
        "This cmdlet returns an Amazon.AppSync.Model.GetDataSourceIntrospectionResponse object containing multiple properties."
    )]
    public partial class GetASYNDataSourceIntrospectionCmdlet : AmazonAppSyncClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter IncludeModelsSDL
        /// <summary>
        /// <para>
        /// <para>A boolean flag that determines whether SDL should be generated for introspected types.
        /// If set to <c>true</c>, each model will contain an <c>sdl</c> property that contains
        /// the SDL for that type. The SDL only contains the type data and no additional metadata
        /// or directives. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? IncludeModelsSDL { get; set; }
        #endregion
        
        #region Parameter IntrospectionId
        /// <summary>
        /// <para>
        /// <para>The introspection ID. Each introspection contains a unique ID that can be used to
        /// reference the instrospection record.</para>
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
        public System.String IntrospectionId { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of introspected types that will be returned in a single response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>Determines the number of types to be returned in a single response before paginating.
        /// This value is typically taken from <c>nextToken</c> value from the previous response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AppSync.Model.GetDataSourceIntrospectionResponse).
        /// Specifying the name of a property of type Amazon.AppSync.Model.GetDataSourceIntrospectionResponse will result in that property being returned.
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AppSync.Model.GetDataSourceIntrospectionResponse, GetASYNDataSourceIntrospectionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.IncludeModelsSDL = this.IncludeModelsSDL;
            context.IntrospectionId = this.IntrospectionId;
            #if MODULAR
            if (this.IntrospectionId == null && ParameterWasBound(nameof(this.IntrospectionId)))
            {
                WriteWarning("You are passing $null as a value for parameter IntrospectionId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            
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
            var request = new Amazon.AppSync.Model.GetDataSourceIntrospectionRequest();
            
            if (cmdletContext.IncludeModelsSDL != null)
            {
                request.IncludeModelsSDL = cmdletContext.IncludeModelsSDL.Value;
            }
            if (cmdletContext.IntrospectionId != null)
            {
                request.IntrospectionId = cmdletContext.IntrospectionId;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
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
        
        private Amazon.AppSync.Model.GetDataSourceIntrospectionResponse CallAWSServiceOperation(IAmazonAppSync client, Amazon.AppSync.Model.GetDataSourceIntrospectionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS AppSync", "GetDataSourceIntrospection");
            try
            {
                return client.GetDataSourceIntrospectionAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Boolean? IncludeModelsSDL { get; set; }
            public System.String IntrospectionId { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.AppSync.Model.GetDataSourceIntrospectionResponse, GetASYNDataSourceIntrospectionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
