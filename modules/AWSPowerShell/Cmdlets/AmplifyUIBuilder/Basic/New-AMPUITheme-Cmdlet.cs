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
using Amazon.AmplifyUIBuilder;
using Amazon.AmplifyUIBuilder.Model;

namespace Amazon.PowerShell.Cmdlets.AMPUI
{
    /// <summary>
    /// Creates a theme to apply to the components in an Amplify app.
    /// </summary>
    [Cmdlet("New", "AMPUITheme", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.AmplifyUIBuilder.Model.Theme")]
    [AWSCmdlet("Calls the AWS Amplify UI Builder CreateTheme API operation.", Operation = new[] {"CreateTheme"}, SelectReturnType = typeof(Amazon.AmplifyUIBuilder.Model.CreateThemeResponse))]
    [AWSCmdletOutput("Amazon.AmplifyUIBuilder.Model.Theme or Amazon.AmplifyUIBuilder.Model.CreateThemeResponse",
        "This cmdlet returns an Amazon.AmplifyUIBuilder.Model.Theme object.",
        "The service call response (type Amazon.AmplifyUIBuilder.Model.CreateThemeResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewAMPUIThemeCmdlet : AmazonAmplifyUIBuilderClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AppId
        /// <summary>
        /// <para>
        /// <para>The unique ID of the Amplify app associated with the theme.</para>
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
        /// <para>The name of the backend environment that is a part of the Amplify app.</para>
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
        
        #region Parameter ThemeToCreate_Name
        /// <summary>
        /// <para>
        /// <para>The name of the theme.</para>
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
        public System.String ThemeToCreate_Name { get; set; }
        #endregion
        
        #region Parameter ThemeToCreate_Override
        /// <summary>
        /// <para>
        /// <para>Describes the properties that can be overriden to customize an instance of the theme.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ThemeToCreate_Overrides")]
        public Amazon.AmplifyUIBuilder.Model.ThemeValues[] ThemeToCreate_Override { get; set; }
        #endregion
        
        #region Parameter ThemeToCreate_Tag
        /// <summary>
        /// <para>
        /// <para>One or more key-value pairs to use when tagging the theme data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ThemeToCreate_Tags")]
        public System.Collections.Hashtable ThemeToCreate_Tag { get; set; }
        #endregion
        
        #region Parameter ThemeToCreate_Value
        /// <summary>
        /// <para>
        /// <para>A list of key-value pairs that deﬁnes the properties of the theme.</para>
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
        [Alias("ThemeToCreate_Values")]
        public Amazon.AmplifyUIBuilder.Model.ThemeValues[] ThemeToCreate_Value { get; set; }
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AmplifyUIBuilder.Model.CreateThemeResponse).
        /// Specifying the name of a property of type Amazon.AmplifyUIBuilder.Model.CreateThemeResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Entity";
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-AMPUITheme (CreateTheme)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AmplifyUIBuilder.Model.CreateThemeResponse, NewAMPUIThemeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
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
            context.ThemeToCreate_Name = this.ThemeToCreate_Name;
            #if MODULAR
            if (this.ThemeToCreate_Name == null && ParameterWasBound(nameof(this.ThemeToCreate_Name)))
            {
                WriteWarning("You are passing $null as a value for parameter ThemeToCreate_Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.ThemeToCreate_Override != null)
            {
                context.ThemeToCreate_Override = new List<Amazon.AmplifyUIBuilder.Model.ThemeValues>(this.ThemeToCreate_Override);
            }
            if (this.ThemeToCreate_Tag != null)
            {
                context.ThemeToCreate_Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.ThemeToCreate_Tag.Keys)
                {
                    context.ThemeToCreate_Tag.Add((String)hashKey, (String)(this.ThemeToCreate_Tag[hashKey]));
                }
            }
            if (this.ThemeToCreate_Value != null)
            {
                context.ThemeToCreate_Value = new List<Amazon.AmplifyUIBuilder.Model.ThemeValues>(this.ThemeToCreate_Value);
            }
            #if MODULAR
            if (this.ThemeToCreate_Value == null && ParameterWasBound(nameof(this.ThemeToCreate_Value)))
            {
                WriteWarning("You are passing $null as a value for parameter ThemeToCreate_Value which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.AmplifyUIBuilder.Model.CreateThemeRequest();
            
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
            
             // populate ThemeToCreate
            var requestThemeToCreateIsNull = true;
            request.ThemeToCreate = new Amazon.AmplifyUIBuilder.Model.CreateThemeData();
            System.String requestThemeToCreate_themeToCreate_Name = null;
            if (cmdletContext.ThemeToCreate_Name != null)
            {
                requestThemeToCreate_themeToCreate_Name = cmdletContext.ThemeToCreate_Name;
            }
            if (requestThemeToCreate_themeToCreate_Name != null)
            {
                request.ThemeToCreate.Name = requestThemeToCreate_themeToCreate_Name;
                requestThemeToCreateIsNull = false;
            }
            List<Amazon.AmplifyUIBuilder.Model.ThemeValues> requestThemeToCreate_themeToCreate_Override = null;
            if (cmdletContext.ThemeToCreate_Override != null)
            {
                requestThemeToCreate_themeToCreate_Override = cmdletContext.ThemeToCreate_Override;
            }
            if (requestThemeToCreate_themeToCreate_Override != null)
            {
                request.ThemeToCreate.Overrides = requestThemeToCreate_themeToCreate_Override;
                requestThemeToCreateIsNull = false;
            }
            Dictionary<System.String, System.String> requestThemeToCreate_themeToCreate_Tag = null;
            if (cmdletContext.ThemeToCreate_Tag != null)
            {
                requestThemeToCreate_themeToCreate_Tag = cmdletContext.ThemeToCreate_Tag;
            }
            if (requestThemeToCreate_themeToCreate_Tag != null)
            {
                request.ThemeToCreate.Tags = requestThemeToCreate_themeToCreate_Tag;
                requestThemeToCreateIsNull = false;
            }
            List<Amazon.AmplifyUIBuilder.Model.ThemeValues> requestThemeToCreate_themeToCreate_Value = null;
            if (cmdletContext.ThemeToCreate_Value != null)
            {
                requestThemeToCreate_themeToCreate_Value = cmdletContext.ThemeToCreate_Value;
            }
            if (requestThemeToCreate_themeToCreate_Value != null)
            {
                request.ThemeToCreate.Values = requestThemeToCreate_themeToCreate_Value;
                requestThemeToCreateIsNull = false;
            }
             // determine if request.ThemeToCreate should be set to null
            if (requestThemeToCreateIsNull)
            {
                request.ThemeToCreate = null;
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
        
        private Amazon.AmplifyUIBuilder.Model.CreateThemeResponse CallAWSServiceOperation(IAmazonAmplifyUIBuilder client, Amazon.AmplifyUIBuilder.Model.CreateThemeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Amplify UI Builder", "CreateTheme");
            try
            {
                #if DESKTOP
                return client.CreateTheme(request);
                #elif CORECLR
                return client.CreateThemeAsync(request).GetAwaiter().GetResult();
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
            public System.String ThemeToCreate_Name { get; set; }
            public List<Amazon.AmplifyUIBuilder.Model.ThemeValues> ThemeToCreate_Override { get; set; }
            public Dictionary<System.String, System.String> ThemeToCreate_Tag { get; set; }
            public List<Amazon.AmplifyUIBuilder.Model.ThemeValues> ThemeToCreate_Value { get; set; }
            public System.Func<Amazon.AmplifyUIBuilder.Model.CreateThemeResponse, NewAMPUIThemeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Entity;
        }
        
    }
}
