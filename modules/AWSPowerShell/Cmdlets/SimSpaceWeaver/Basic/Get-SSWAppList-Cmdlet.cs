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
using Amazon.SimSpaceWeaver;
using Amazon.SimSpaceWeaver.Model;

namespace Amazon.PowerShell.Cmdlets.SSW
{
    /// <summary>
    /// Lists all custom apps or service apps for the given simulation and domain.
    /// </summary>
    [Cmdlet("Get", "SSWAppList")]
    [OutputType("Amazon.SimSpaceWeaver.Model.SimulationAppMetadata")]
    [AWSCmdlet("Calls the AWS SimSpace Weaver ListApps API operation.", Operation = new[] {"ListApps"}, SelectReturnType = typeof(Amazon.SimSpaceWeaver.Model.ListAppsResponse))]
    [AWSCmdletOutput("Amazon.SimSpaceWeaver.Model.SimulationAppMetadata or Amazon.SimSpaceWeaver.Model.ListAppsResponse",
        "This cmdlet returns a collection of Amazon.SimSpaceWeaver.Model.SimulationAppMetadata objects.",
        "The service call response (type Amazon.SimSpaceWeaver.Model.ListAppsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetSSWAppListCmdlet : AmazonSimSpaceWeaverClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Domain
        /// <summary>
        /// <para>
        /// <para>The name of the domain that you want to list apps for.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Domain { get; set; }
        #endregion
        
        #region Parameter Simulation
        /// <summary>
        /// <para>
        /// <para>The name of the simulation that you want to list apps for.</para>
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
        public System.String Simulation { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of apps to list.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>If SimSpace Weaver returns <c>nextToken</c>, then there are more results available.
        /// The value of <c>nextToken</c> is a unique pagination token for each page. To retrieve
        /// the next page, call the operation again using the returned token. Keep all other arguments
        /// unchanged. If no results remain, then <c>nextToken</c> is set to <c>null</c>. Each
        /// pagination token expires after 24 hours. If you provide a token that isn't valid,
        /// then you receive an <i>HTTP 400 ValidationException</i> error.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Apps'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SimSpaceWeaver.Model.ListAppsResponse).
        /// Specifying the name of a property of type Amazon.SimSpaceWeaver.Model.ListAppsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Apps";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Simulation parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Simulation' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Simulation' instead. This parameter will be removed in a future version.")]
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
                context.Select = CreateSelectDelegate<Amazon.SimSpaceWeaver.Model.ListAppsResponse, GetSSWAppListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Simulation;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Domain = this.Domain;
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.Simulation = this.Simulation;
            #if MODULAR
            if (this.Simulation == null && ParameterWasBound(nameof(this.Simulation)))
            {
                WriteWarning("You are passing $null as a value for parameter Simulation which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SimSpaceWeaver.Model.ListAppsRequest();
            
            if (cmdletContext.Domain != null)
            {
                request.Domain = cmdletContext.Domain;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.Simulation != null)
            {
                request.Simulation = cmdletContext.Simulation;
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
        
        private Amazon.SimSpaceWeaver.Model.ListAppsResponse CallAWSServiceOperation(IAmazonSimSpaceWeaver client, Amazon.SimSpaceWeaver.Model.ListAppsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS SimSpace Weaver", "ListApps");
            try
            {
                #if DESKTOP
                return client.ListApps(request);
                #elif CORECLR
                return client.ListAppsAsync(request).GetAwaiter().GetResult();
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
            public System.String Domain { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.String Simulation { get; set; }
            public System.Func<Amazon.SimSpaceWeaver.Model.ListAppsResponse, GetSSWAppListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Apps;
        }
        
    }
}
