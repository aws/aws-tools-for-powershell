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
using Amazon.EntityResolution;
using Amazon.EntityResolution.Model;

namespace Amazon.PowerShell.Cmdlets.ERES
{
    /// <summary>
    /// Returns the corresponding Match ID of a customer record if the record has been processed
    /// in a rule-based matching workflow.
    /// 
    ///  
    /// <para>
    /// You can call this API as a dry run of an incremental load on the rule-based matching
    /// workflow.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "ERESMatchId")]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS EntityResolution GetMatchId API operation.", Operation = new[] {"GetMatchId"}, SelectReturnType = typeof(Amazon.EntityResolution.Model.GetMatchIdResponse))]
    [AWSCmdletOutput("System.String or Amazon.EntityResolution.Model.GetMatchIdResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.EntityResolution.Model.GetMatchIdResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetERESMatchIdCmdlet : AmazonEntityResolutionClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ApplyNormalization
        /// <summary>
        /// <para>
        /// <para>Normalizes the attributes defined in the schema in the input data. For example, if
        /// an attribute has an <c>AttributeType</c> of <c>PHONE_NUMBER</c>, and the data in the
        /// input table is in a format of 1234567890, Entity Resolution will normalize this field
        /// in the output to (123)-456-7890.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ApplyNormalization { get; set; }
        #endregion
        
        #region Parameter Record
        /// <summary>
        /// <para>
        /// <para>The record to fetch the Match ID for.</para>
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
        public System.Collections.Hashtable Record { get; set; }
        #endregion
        
        #region Parameter WorkflowName
        /// <summary>
        /// <para>
        /// <para>The name of the workflow.</para>
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
        public System.String WorkflowName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'MatchId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EntityResolution.Model.GetMatchIdResponse).
        /// Specifying the name of a property of type Amazon.EntityResolution.Model.GetMatchIdResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "MatchId";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the WorkflowName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^WorkflowName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^WorkflowName' instead. This parameter will be removed in a future version.")]
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
                context.Select = CreateSelectDelegate<Amazon.EntityResolution.Model.GetMatchIdResponse, GetERESMatchIdCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.WorkflowName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ApplyNormalization = this.ApplyNormalization;
            if (this.Record != null)
            {
                context.Record = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Record.Keys)
                {
                    context.Record.Add((String)hashKey, (System.String)(this.Record[hashKey]));
                }
            }
            #if MODULAR
            if (this.Record == null && ParameterWasBound(nameof(this.Record)))
            {
                WriteWarning("You are passing $null as a value for parameter Record which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.WorkflowName = this.WorkflowName;
            #if MODULAR
            if (this.WorkflowName == null && ParameterWasBound(nameof(this.WorkflowName)))
            {
                WriteWarning("You are passing $null as a value for parameter WorkflowName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.EntityResolution.Model.GetMatchIdRequest();
            
            if (cmdletContext.ApplyNormalization != null)
            {
                request.ApplyNormalization = cmdletContext.ApplyNormalization.Value;
            }
            if (cmdletContext.Record != null)
            {
                request.Record = cmdletContext.Record;
            }
            if (cmdletContext.WorkflowName != null)
            {
                request.WorkflowName = cmdletContext.WorkflowName;
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
        
        private Amazon.EntityResolution.Model.GetMatchIdResponse CallAWSServiceOperation(IAmazonEntityResolution client, Amazon.EntityResolution.Model.GetMatchIdRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS EntityResolution", "GetMatchId");
            try
            {
                #if DESKTOP
                return client.GetMatchId(request);
                #elif CORECLR
                return client.GetMatchIdAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? ApplyNormalization { get; set; }
            public Dictionary<System.String, System.String> Record { get; set; }
            public System.String WorkflowName { get; set; }
            public System.Func<Amazon.EntityResolution.Model.GetMatchIdResponse, GetERESMatchIdCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.MatchId;
        }
        
    }
}
