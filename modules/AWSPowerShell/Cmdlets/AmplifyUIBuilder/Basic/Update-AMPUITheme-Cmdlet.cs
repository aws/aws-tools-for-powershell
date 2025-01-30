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
using Amazon.AmplifyUIBuilder;
using Amazon.AmplifyUIBuilder.Model;

namespace Amazon.PowerShell.Cmdlets.AMPUI
{
    /// <summary>
    /// Updates an existing theme.
    /// </summary>
    [Cmdlet("Update", "AMPUITheme", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.AmplifyUIBuilder.Model.Theme")]
    [AWSCmdlet("Calls the AWS Amplify UI Builder UpdateTheme API operation.", Operation = new[] {"UpdateTheme"}, SelectReturnType = typeof(Amazon.AmplifyUIBuilder.Model.UpdateThemeResponse))]
    [AWSCmdletOutput("Amazon.AmplifyUIBuilder.Model.Theme or Amazon.AmplifyUIBuilder.Model.UpdateThemeResponse",
        "This cmdlet returns an Amazon.AmplifyUIBuilder.Model.Theme object.",
        "The service call response (type Amazon.AmplifyUIBuilder.Model.UpdateThemeResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateAMPUIThemeCmdlet : AmazonAmplifyUIBuilderClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AppId
        /// <summary>
        /// <para>
        /// <para>The unique ID for the Amplify app.</para>
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
        public System.String AppId { get; set; }
        #endregion
        
        #region Parameter EnvironmentName
        /// <summary>
        /// <para>
        /// <para>The name of the backend environment that is part of the Amplify app.</para>
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
        public System.String EnvironmentName { get; set; }
        #endregion
        
        #region Parameter Id
        /// <summary>
        /// <para>
        /// <para>The unique ID for the theme.</para>
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
        public System.String Id { get; set; }
        #endregion
        
        #region Parameter UpdatedTheme_Id
        /// <summary>
        /// <para>
        /// <para>The unique ID of the theme to update.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String UpdatedTheme_Id { get; set; }
        #endregion
        
        #region Parameter UpdatedTheme_Name
        /// <summary>
        /// <para>
        /// <para>The name of the theme to update.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String UpdatedTheme_Name { get; set; }
        #endregion
        
        #region Parameter UpdatedTheme_Override
        /// <summary>
        /// <para>
        /// <para>Describes the properties that can be overriden to customize the theme.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("UpdatedTheme_Overrides")]
        public Amazon.AmplifyUIBuilder.Model.ThemeValues[] UpdatedTheme_Override { get; set; }
        #endregion
        
        #region Parameter UpdatedTheme_Value
        /// <summary>
        /// <para>
        /// <para>A list of key-value pairs that define the theme's properties.</para>
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
        [Alias("UpdatedTheme_Values")]
        public Amazon.AmplifyUIBuilder.Model.ThemeValues[] UpdatedTheme_Value { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>The unique client token.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Entity'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AmplifyUIBuilder.Model.UpdateThemeResponse).
        /// Specifying the name of a property of type Amazon.AmplifyUIBuilder.Model.UpdateThemeResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Entity";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Id parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Id' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Id' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Id), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-AMPUITheme (UpdateTheme)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AmplifyUIBuilder.Model.UpdateThemeResponse, UpdateAMPUIThemeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Id;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AppId = this.AppId;
            #if MODULAR
            if (this.AppId == null && ParameterWasBound(nameof(this.AppId)))
            {
                WriteWarning("You are passing $null as a value for parameter AppId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientToken = this.ClientToken;
            context.EnvironmentName = this.EnvironmentName;
            #if MODULAR
            if (this.EnvironmentName == null && ParameterWasBound(nameof(this.EnvironmentName)))
            {
                WriteWarning("You are passing $null as a value for parameter EnvironmentName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Id = this.Id;
            #if MODULAR
            if (this.Id == null && ParameterWasBound(nameof(this.Id)))
            {
                WriteWarning("You are passing $null as a value for parameter Id which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.UpdatedTheme_Id = this.UpdatedTheme_Id;
            context.UpdatedTheme_Name = this.UpdatedTheme_Name;
            if (this.UpdatedTheme_Override != null)
            {
                context.UpdatedTheme_Override = new List<Amazon.AmplifyUIBuilder.Model.ThemeValues>(this.UpdatedTheme_Override);
            }
            if (this.UpdatedTheme_Value != null)
            {
                context.UpdatedTheme_Value = new List<Amazon.AmplifyUIBuilder.Model.ThemeValues>(this.UpdatedTheme_Value);
            }
            #if MODULAR
            if (this.UpdatedTheme_Value == null && ParameterWasBound(nameof(this.UpdatedTheme_Value)))
            {
                WriteWarning("You are passing $null as a value for parameter UpdatedTheme_Value which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.AmplifyUIBuilder.Model.UpdateThemeRequest();
            
            if (cmdletContext.AppId != null)
            {
                request.AppId = cmdletContext.AppId;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.EnvironmentName != null)
            {
                request.EnvironmentName = cmdletContext.EnvironmentName;
            }
            if (cmdletContext.Id != null)
            {
                request.Id = cmdletContext.Id;
            }
            
             // populate UpdatedTheme
            var requestUpdatedThemeIsNull = true;
            request.UpdatedTheme = new Amazon.AmplifyUIBuilder.Model.UpdateThemeData();
            System.String requestUpdatedTheme_updatedTheme_Id = null;
            if (cmdletContext.UpdatedTheme_Id != null)
            {
                requestUpdatedTheme_updatedTheme_Id = cmdletContext.UpdatedTheme_Id;
            }
            if (requestUpdatedTheme_updatedTheme_Id != null)
            {
                request.UpdatedTheme.Id = requestUpdatedTheme_updatedTheme_Id;
                requestUpdatedThemeIsNull = false;
            }
            System.String requestUpdatedTheme_updatedTheme_Name = null;
            if (cmdletContext.UpdatedTheme_Name != null)
            {
                requestUpdatedTheme_updatedTheme_Name = cmdletContext.UpdatedTheme_Name;
            }
            if (requestUpdatedTheme_updatedTheme_Name != null)
            {
                request.UpdatedTheme.Name = requestUpdatedTheme_updatedTheme_Name;
                requestUpdatedThemeIsNull = false;
            }
            List<Amazon.AmplifyUIBuilder.Model.ThemeValues> requestUpdatedTheme_updatedTheme_Override = null;
            if (cmdletContext.UpdatedTheme_Override != null)
            {
                requestUpdatedTheme_updatedTheme_Override = cmdletContext.UpdatedTheme_Override;
            }
            if (requestUpdatedTheme_updatedTheme_Override != null)
            {
                request.UpdatedTheme.Overrides = requestUpdatedTheme_updatedTheme_Override;
                requestUpdatedThemeIsNull = false;
            }
            List<Amazon.AmplifyUIBuilder.Model.ThemeValues> requestUpdatedTheme_updatedTheme_Value = null;
            if (cmdletContext.UpdatedTheme_Value != null)
            {
                requestUpdatedTheme_updatedTheme_Value = cmdletContext.UpdatedTheme_Value;
            }
            if (requestUpdatedTheme_updatedTheme_Value != null)
            {
                request.UpdatedTheme.Values = requestUpdatedTheme_updatedTheme_Value;
                requestUpdatedThemeIsNull = false;
            }
             // determine if request.UpdatedTheme should be set to null
            if (requestUpdatedThemeIsNull)
            {
                request.UpdatedTheme = null;
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
        
        private Amazon.AmplifyUIBuilder.Model.UpdateThemeResponse CallAWSServiceOperation(IAmazonAmplifyUIBuilder client, Amazon.AmplifyUIBuilder.Model.UpdateThemeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Amplify UI Builder", "UpdateTheme");
            try
            {
                #if DESKTOP
                return client.UpdateTheme(request);
                #elif CORECLR
                return client.UpdateThemeAsync(request).GetAwaiter().GetResult();
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
            public System.String AppId { get; set; }
            public System.String ClientToken { get; set; }
            public System.String EnvironmentName { get; set; }
            public System.String Id { get; set; }
            public System.String UpdatedTheme_Id { get; set; }
            public System.String UpdatedTheme_Name { get; set; }
            public List<Amazon.AmplifyUIBuilder.Model.ThemeValues> UpdatedTheme_Override { get; set; }
            public List<Amazon.AmplifyUIBuilder.Model.ThemeValues> UpdatedTheme_Value { get; set; }
            public System.Func<Amazon.AmplifyUIBuilder.Model.UpdateThemeResponse, UpdateAMPUIThemeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Entity;
        }
        
    }
}
