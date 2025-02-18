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
using Amazon.Schemas;
using Amazon.Schemas.Model;

namespace Amazon.PowerShell.Cmdlets.SCHM
{
    /// <summary>
    /// Get the discovered schema that was generated based on sampled events.
    /// </summary>
    [Cmdlet("Get", "SCHMDiscoveredSchema")]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon EventBridge Schema Registry GetDiscoveredSchema API operation.", Operation = new[] {"GetDiscoveredSchema"}, SelectReturnType = typeof(Amazon.Schemas.Model.GetDiscoveredSchemaResponse))]
    [AWSCmdletOutput("System.String or Amazon.Schemas.Model.GetDiscoveredSchemaResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Schemas.Model.GetDiscoveredSchemaResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetSCHMDiscoveredSchemaCmdlet : AmazonSchemasClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Event
        /// <summary>
        /// <para>
        /// <para>An array of strings where each string is a JSON event. These are the events that were
        /// used to generate the schema. The array includes a single type of event and has a maximum
        /// size of 10 events.</para>
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
        [Alias("Events")]
        public System.String[] Event { get; set; }
        #endregion
        
        #region Parameter Type
        /// <summary>
        /// <para>
        /// <para>The type of event.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Schemas.Type")]
        public Amazon.Schemas.Type Type { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Content'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Schemas.Model.GetDiscoveredSchemaResponse).
        /// Specifying the name of a property of type Amazon.Schemas.Model.GetDiscoveredSchemaResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Content";
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
                context.Select = CreateSelectDelegate<Amazon.Schemas.Model.GetDiscoveredSchemaResponse, GetSCHMDiscoveredSchemaCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Event != null)
            {
                context.Event = new List<System.String>(this.Event);
            }
            #if MODULAR
            if (this.Event == null && ParameterWasBound(nameof(this.Event)))
            {
                WriteWarning("You are passing $null as a value for parameter Event which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Type = this.Type;
            #if MODULAR
            if (this.Type == null && ParameterWasBound(nameof(this.Type)))
            {
                WriteWarning("You are passing $null as a value for parameter Type which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Schemas.Model.GetDiscoveredSchemaRequest();
            
            if (cmdletContext.Event != null)
            {
                request.Events = cmdletContext.Event;
            }
            if (cmdletContext.Type != null)
            {
                request.Type = cmdletContext.Type;
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
        
        private Amazon.Schemas.Model.GetDiscoveredSchemaResponse CallAWSServiceOperation(IAmazonSchemas client, Amazon.Schemas.Model.GetDiscoveredSchemaRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon EventBridge Schema Registry", "GetDiscoveredSchema");
            try
            {
                return client.GetDiscoveredSchemaAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<System.String> Event { get; set; }
            public Amazon.Schemas.Type Type { get; set; }
            public System.Func<Amazon.Schemas.Model.GetDiscoveredSchemaResponse, GetSCHMDiscoveredSchemaCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Content;
        }
        
    }
}
