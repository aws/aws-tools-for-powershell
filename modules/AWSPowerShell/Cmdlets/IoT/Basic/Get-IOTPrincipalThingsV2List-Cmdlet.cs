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
using Amazon.IoT;
using Amazon.IoT.Model;

namespace Amazon.PowerShell.Cmdlets.IOT
{
    /// <summary>
    /// Lists the things associated with the specified principal. A principal can be an X.509
    /// certificate or an Amazon Cognito ID.
    /// 
    ///  
    /// <para>
    /// Requires permission to access the <a href="https://docs.aws.amazon.com/service-authorization/latest/reference/list_awsiot.html#awsiot-actions-as-permissions">ListPrincipalThings</a>
    /// action.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "IOTPrincipalThingsV2List")]
    [OutputType("Amazon.IoT.Model.PrincipalThingObject")]
    [AWSCmdlet("Calls the AWS IoT ListPrincipalThingsV2 API operation.", Operation = new[] {"ListPrincipalThingsV2"}, SelectReturnType = typeof(Amazon.IoT.Model.ListPrincipalThingsV2Response))]
    [AWSCmdletOutput("Amazon.IoT.Model.PrincipalThingObject or Amazon.IoT.Model.ListPrincipalThingsV2Response",
        "This cmdlet returns a collection of Amazon.IoT.Model.PrincipalThingObject objects.",
        "The service call response (type Amazon.IoT.Model.ListPrincipalThingsV2Response) can be returned by specifying '-Select *'."
    )]
    public partial class GetIOTPrincipalThingsV2ListCmdlet : AmazonIoTClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Principal
        /// <summary>
        /// <para>
        /// <para>The principal. A principal can be an X.509 certificate or an Amazon Cognito ID.</para>
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
        public System.String Principal { get; set; }
        #endregion
        
        #region Parameter ThingPrincipalType
        /// <summary>
        /// <para>
        /// <para>The type of the relation you want to filter in the response. If no value is provided
        /// in this field, the response will list all things, including both the <c>EXCLUSIVE_THING</c>
        /// and <c>NON_EXCLUSIVE_THING</c> attachment types.</para><ul><li><para><c>EXCLUSIVE_THING</c> - Attaches the specified principal to the specified thing,
        /// exclusively. The thing will be the only thing that’s attached to the principal.</para></li></ul><ul><li><para><c>NON_EXCLUSIVE_THING</c> - Attaches the specified principal to the specified thing.
        /// Multiple things can be attached to the principal.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.IoT.ThingPrincipalType")]
        public Amazon.IoT.ThingPrincipalType ThingPrincipalType { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return in this operation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>To retrieve the next set of results, the <c>nextToken</c> value from a previous response;
        /// otherwise <b>null</b> to receive the first set of results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'PrincipalThingObjects'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoT.Model.ListPrincipalThingsV2Response).
        /// Specifying the name of a property of type Amazon.IoT.Model.ListPrincipalThingsV2Response will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "PrincipalThingObjects";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Principal parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Principal' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Principal' instead. This parameter will be removed in a future version.")]
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
                context.Select = CreateSelectDelegate<Amazon.IoT.Model.ListPrincipalThingsV2Response, GetIOTPrincipalThingsV2ListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Principal;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.Principal = this.Principal;
            #if MODULAR
            if (this.Principal == null && ParameterWasBound(nameof(this.Principal)))
            {
                WriteWarning("You are passing $null as a value for parameter Principal which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ThingPrincipalType = this.ThingPrincipalType;
            
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
            var request = new Amazon.IoT.Model.ListPrincipalThingsV2Request();
            
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.Principal != null)
            {
                request.Principal = cmdletContext.Principal;
            }
            if (cmdletContext.ThingPrincipalType != null)
            {
                request.ThingPrincipalType = cmdletContext.ThingPrincipalType;
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
        
        private Amazon.IoT.Model.ListPrincipalThingsV2Response CallAWSServiceOperation(IAmazonIoT client, Amazon.IoT.Model.ListPrincipalThingsV2Request request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT", "ListPrincipalThingsV2");
            try
            {
                #if DESKTOP
                return client.ListPrincipalThingsV2(request);
                #elif CORECLR
                return client.ListPrincipalThingsV2Async(request).GetAwaiter().GetResult();
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
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.String Principal { get; set; }
            public Amazon.IoT.ThingPrincipalType ThingPrincipalType { get; set; }
            public System.Func<Amazon.IoT.Model.ListPrincipalThingsV2Response, GetIOTPrincipalThingsV2ListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.PrincipalThingObjects;
        }
        
    }
}
