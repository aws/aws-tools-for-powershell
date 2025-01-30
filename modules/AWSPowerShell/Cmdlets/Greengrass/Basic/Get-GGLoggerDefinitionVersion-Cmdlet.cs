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
using Amazon.Greengrass;
using Amazon.Greengrass.Model;

namespace Amazon.PowerShell.Cmdlets.GG
{
    /// <summary>
    /// Retrieves information about a logger definition version.
    /// </summary>
    [Cmdlet("Get", "GGLoggerDefinitionVersion")]
    [OutputType("Amazon.Greengrass.Model.GetLoggerDefinitionVersionResponse")]
    [AWSCmdlet("Calls the AWS Greengrass GetLoggerDefinitionVersion API operation.", Operation = new[] {"GetLoggerDefinitionVersion"}, SelectReturnType = typeof(Amazon.Greengrass.Model.GetLoggerDefinitionVersionResponse))]
    [AWSCmdletOutput("Amazon.Greengrass.Model.GetLoggerDefinitionVersionResponse",
        "This cmdlet returns an Amazon.Greengrass.Model.GetLoggerDefinitionVersionResponse object containing multiple properties."
    )]
    public partial class GetGGLoggerDefinitionVersionCmdlet : AmazonGreengrassClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter LoggerDefinitionId
        /// <summary>
        /// <para>
        /// The ID of the logger definition.
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
        public System.String LoggerDefinitionId { get; set; }
        #endregion
        
        #region Parameter LoggerDefinitionVersionId
        /// <summary>
        /// <para>
        /// The ID of the logger definition
        /// version. This value maps to the ''Version'' property of the corresponding ''VersionInformation''
        /// object, which is returned by ''ListLoggerDefinitionVersions'' requests. If the version
        /// is the last one that was associated with a logger definition, the value also maps
        /// to the ''LatestVersion'' property of the corresponding ''DefinitionInformation'' object.
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
        public System.String LoggerDefinitionVersionId { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// The token for the next set of results, or ''null''
        /// if there are no additional results.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Greengrass.Model.GetLoggerDefinitionVersionResponse).
        /// Specifying the name of a property of type Amazon.Greengrass.Model.GetLoggerDefinitionVersionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the LoggerDefinitionVersionId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^LoggerDefinitionVersionId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^LoggerDefinitionVersionId' instead. This parameter will be removed in a future version.")]
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
                context.Select = CreateSelectDelegate<Amazon.Greengrass.Model.GetLoggerDefinitionVersionResponse, GetGGLoggerDefinitionVersionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.LoggerDefinitionVersionId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.LoggerDefinitionId = this.LoggerDefinitionId;
            #if MODULAR
            if (this.LoggerDefinitionId == null && ParameterWasBound(nameof(this.LoggerDefinitionId)))
            {
                WriteWarning("You are passing $null as a value for parameter LoggerDefinitionId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.LoggerDefinitionVersionId = this.LoggerDefinitionVersionId;
            #if MODULAR
            if (this.LoggerDefinitionVersionId == null && ParameterWasBound(nameof(this.LoggerDefinitionVersionId)))
            {
                WriteWarning("You are passing $null as a value for parameter LoggerDefinitionVersionId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            var request = new Amazon.Greengrass.Model.GetLoggerDefinitionVersionRequest();
            
            if (cmdletContext.LoggerDefinitionId != null)
            {
                request.LoggerDefinitionId = cmdletContext.LoggerDefinitionId;
            }
            if (cmdletContext.LoggerDefinitionVersionId != null)
            {
                request.LoggerDefinitionVersionId = cmdletContext.LoggerDefinitionVersionId;
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
        
        private Amazon.Greengrass.Model.GetLoggerDefinitionVersionResponse CallAWSServiceOperation(IAmazonGreengrass client, Amazon.Greengrass.Model.GetLoggerDefinitionVersionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Greengrass", "GetLoggerDefinitionVersion");
            try
            {
                #if DESKTOP
                return client.GetLoggerDefinitionVersion(request);
                #elif CORECLR
                return client.GetLoggerDefinitionVersionAsync(request).GetAwaiter().GetResult();
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
            public System.String LoggerDefinitionId { get; set; }
            public System.String LoggerDefinitionVersionId { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.Greengrass.Model.GetLoggerDefinitionVersionResponse, GetGGLoggerDefinitionVersionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
