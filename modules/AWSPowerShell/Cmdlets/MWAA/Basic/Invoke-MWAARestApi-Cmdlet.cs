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
using Amazon.MWAA;
using Amazon.MWAA.Model;

namespace Amazon.PowerShell.Cmdlets.MWAA
{
    /// <summary>
    /// Invokes the Apache Airflow REST API on the webserver with the specified inputs. To
    /// learn more, see <a href="https://docs.aws.amazon.com/mwaa/latest/userguide/access-mwaa-apache-airflow-rest-api.html">Using
    /// the Apache Airflow REST API</a>
    /// </summary>
    [Cmdlet("Invoke", "MWAARestApi", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.MWAA.Model.InvokeRestApiResponse")]
    [AWSCmdlet("Calls the AmazonMWAA InvokeRestApi API operation.", Operation = new[] {"InvokeRestApi"}, SelectReturnType = typeof(Amazon.MWAA.Model.InvokeRestApiResponse))]
    [AWSCmdletOutput("Amazon.MWAA.Model.InvokeRestApiResponse",
        "This cmdlet returns an Amazon.MWAA.Model.InvokeRestApiResponse object containing multiple properties."
    )]
    public partial class InvokeMWAARestApiCmdlet : AmazonMWAAClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Body
        /// <summary>
        /// <para>
        /// <para>The request body for the Apache Airflow REST API call, provided as a JSON object.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Management.Automation.PSObject Body { get; set; }
        #endregion
        
        #region Parameter Method
        /// <summary>
        /// <para>
        /// <para>The HTTP method used for making Airflow REST API calls. For example, <c>POST</c>.
        /// </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.MWAA.RestApiMethod")]
        public Amazon.MWAA.RestApiMethod Method { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the Amazon MWAA environment. For example, <c>MyMWAAEnvironment</c>.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Path
        /// <summary>
        /// <para>
        /// <para>The Apache Airflow REST API endpoint path to be called. For example, <c>/dags/123456/clearTaskInstances</c>.
        /// For more information, see <a href="https://airflow.apache.org/docs/apache-airflow/stable/stable-rest-api-ref.html">Apache
        /// Airflow API</a></para>
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
        public System.String Path { get; set; }
        #endregion
        
        #region Parameter QueryParameter
        /// <summary>
        /// <para>
        /// <para>Query parameters to be included in the Apache Airflow REST API call, provided as a
        /// JSON object. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("QueryParameters")]
        public System.Management.Automation.PSObject QueryParameter { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MWAA.Model.InvokeRestApiResponse).
        /// Specifying the name of a property of type Amazon.MWAA.Model.InvokeRestApiResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Invoke-MWAARestApi (InvokeRestApi)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MWAA.Model.InvokeRestApiResponse, InvokeMWAARestApiCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Body = this.Body;
            context.Method = this.Method;
            #if MODULAR
            if (this.Method == null && ParameterWasBound(nameof(this.Method)))
            {
                WriteWarning("You are passing $null as a value for parameter Method which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Path = this.Path;
            #if MODULAR
            if (this.Path == null && ParameterWasBound(nameof(this.Path)))
            {
                WriteWarning("You are passing $null as a value for parameter Path which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.QueryParameter = this.QueryParameter;
            
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
            var request = new Amazon.MWAA.Model.InvokeRestApiRequest();
            
            if (cmdletContext.Body != null)
            {
                request.Body = Amazon.PowerShell.Common.DocumentHelper.ToDocument(cmdletContext.Body);
            }
            if (cmdletContext.Method != null)
            {
                request.Method = cmdletContext.Method;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Path != null)
            {
                request.Path = cmdletContext.Path;
            }
            if (cmdletContext.QueryParameter != null)
            {
                request.QueryParameters = Amazon.PowerShell.Common.DocumentHelper.ToDocument(cmdletContext.QueryParameter);
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
        
        private Amazon.MWAA.Model.InvokeRestApiResponse CallAWSServiceOperation(IAmazonMWAA client, Amazon.MWAA.Model.InvokeRestApiRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AmazonMWAA", "InvokeRestApi");
            try
            {
                #if DESKTOP
                return client.InvokeRestApi(request);
                #elif CORECLR
                return client.InvokeRestApiAsync(request).GetAwaiter().GetResult();
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
            public System.Management.Automation.PSObject Body { get; set; }
            public Amazon.MWAA.RestApiMethod Method { get; set; }
            public System.String Name { get; set; }
            public System.String Path { get; set; }
            public System.Management.Automation.PSObject QueryParameter { get; set; }
            public System.Func<Amazon.MWAA.Model.InvokeRestApiResponse, InvokeMWAARestApiCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
