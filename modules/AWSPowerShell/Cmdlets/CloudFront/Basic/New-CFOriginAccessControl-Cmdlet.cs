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
using Amazon.CloudFront;
using Amazon.CloudFront.Model;

namespace Amazon.PowerShell.Cmdlets.CF
{
    /// <summary>
    /// Creates a new origin access control in CloudFront. After you create an origin access
    /// control, you can add it to an origin in a CloudFront distribution so that CloudFront
    /// sends authenticated (signed) requests to the origin.
    /// 
    ///  
    /// <para>
    /// This makes it possible to block public access to the origin, allowing viewers (users)
    /// to access the origin's content only through CloudFront.
    /// </para><para>
    /// For more information about using a CloudFront origin access control, see <a href="https://docs.aws.amazon.com/AmazonCloudFront/latest/DeveloperGuide/private-content-restricting-access-to-origin.html">Restricting
    /// access to an Amazon Web Services origin</a> in the <i>Amazon CloudFront Developer
    /// Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "CFOriginAccessControl", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CloudFront.Model.CreateOriginAccessControlResponse")]
    [AWSCmdlet("Calls the Amazon CloudFront CreateOriginAccessControl API operation.", Operation = new[] {"CreateOriginAccessControl"}, SelectReturnType = typeof(Amazon.CloudFront.Model.CreateOriginAccessControlResponse))]
    [AWSCmdletOutput("Amazon.CloudFront.Model.CreateOriginAccessControlResponse",
        "This cmdlet returns an Amazon.CloudFront.Model.CreateOriginAccessControlResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewCFOriginAccessControlCmdlet : AmazonCloudFrontClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter OriginAccessControlConfig_Description
        /// <summary>
        /// <para>
        /// <para>A description of the origin access control.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OriginAccessControlConfig_Description { get; set; }
        #endregion
        
        #region Parameter OriginAccessControlConfig_Name
        /// <summary>
        /// <para>
        /// <para>A name to identify the origin access control.</para>
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
        public System.String OriginAccessControlConfig_Name { get; set; }
        #endregion
        
        #region Parameter OriginAccessControlConfig_OriginAccessControlOriginType
        /// <summary>
        /// <para>
        /// <para>The type of origin that this origin access control is for.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.CloudFront.OriginAccessControlOriginTypes")]
        public Amazon.CloudFront.OriginAccessControlOriginTypes OriginAccessControlConfig_OriginAccessControlOriginType { get; set; }
        #endregion
        
        #region Parameter OriginAccessControlConfig_SigningBehavior
        /// <summary>
        /// <para>
        /// <para>Specifies which requests CloudFront signs (adds authentication information to). Specify
        /// <code>always</code> for the most common use case. For more information, see <a href="https://docs.aws.amazon.com/AmazonCloudFront/latest/DeveloperGuide/private-content-restricting-access-to-s3.html#oac-advanced-settings">origin
        /// access control advanced settings</a> in the <i>Amazon CloudFront Developer Guide</i>.</para><para>This field can have one of the following values:</para><ul><li><para><code>always</code> – CloudFront signs all origin requests, overwriting the <code>Authorization</code>
        /// header from the viewer request if one exists.</para></li><li><para><code>never</code> – CloudFront doesn't sign any origin requests. This value turns
        /// off origin access control for all origins in all distributions that use this origin
        /// access control.</para></li><li><para><code>no-override</code> – If the viewer request doesn't contain the <code>Authorization</code>
        /// header, then CloudFront signs the origin request. If the viewer request contains the
        /// <code>Authorization</code> header, then CloudFront doesn't sign the origin request
        /// and instead passes along the <code>Authorization</code> header from the viewer request.
        /// <b>WARNING: To pass along the <code>Authorization</code> header from the viewer request,
        /// you <i>must</i> add the <code>Authorization</code> header to a <a href="https://docs.aws.amazon.com/AmazonCloudFront/latest/DeveloperGuide/controlling-the-cache-key.html">cache
        /// policy</a> for all cache behaviors that use origins associated with this origin access
        /// control.</b></para></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.CloudFront.OriginAccessControlSigningBehaviors")]
        public Amazon.CloudFront.OriginAccessControlSigningBehaviors OriginAccessControlConfig_SigningBehavior { get; set; }
        #endregion
        
        #region Parameter OriginAccessControlConfig_SigningProtocol
        /// <summary>
        /// <para>
        /// <para>The signing protocol of the origin access control, which determines how CloudFront
        /// signs (authenticates) requests. The only valid value is <code>sigv4</code>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.CloudFront.OriginAccessControlSigningProtocols")]
        public Amazon.CloudFront.OriginAccessControlSigningProtocols OriginAccessControlConfig_SigningProtocol { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudFront.Model.CreateOriginAccessControlResponse).
        /// Specifying the name of a property of type Amazon.CloudFront.Model.CreateOriginAccessControlResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the OriginAccessControlConfig_Name parameter.
        /// The -PassThru parameter is deprecated, use -Select '^OriginAccessControlConfig_Name' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^OriginAccessControlConfig_Name' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.OriginAccessControlConfig_Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CFOriginAccessControl (CreateOriginAccessControl)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudFront.Model.CreateOriginAccessControlResponse, NewCFOriginAccessControlCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.OriginAccessControlConfig_Name;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.OriginAccessControlConfig_Description = this.OriginAccessControlConfig_Description;
            context.OriginAccessControlConfig_Name = this.OriginAccessControlConfig_Name;
            #if MODULAR
            if (this.OriginAccessControlConfig_Name == null && ParameterWasBound(nameof(this.OriginAccessControlConfig_Name)))
            {
                WriteWarning("You are passing $null as a value for parameter OriginAccessControlConfig_Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.OriginAccessControlConfig_OriginAccessControlOriginType = this.OriginAccessControlConfig_OriginAccessControlOriginType;
            #if MODULAR
            if (this.OriginAccessControlConfig_OriginAccessControlOriginType == null && ParameterWasBound(nameof(this.OriginAccessControlConfig_OriginAccessControlOriginType)))
            {
                WriteWarning("You are passing $null as a value for parameter OriginAccessControlConfig_OriginAccessControlOriginType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.OriginAccessControlConfig_SigningBehavior = this.OriginAccessControlConfig_SigningBehavior;
            #if MODULAR
            if (this.OriginAccessControlConfig_SigningBehavior == null && ParameterWasBound(nameof(this.OriginAccessControlConfig_SigningBehavior)))
            {
                WriteWarning("You are passing $null as a value for parameter OriginAccessControlConfig_SigningBehavior which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.OriginAccessControlConfig_SigningProtocol = this.OriginAccessControlConfig_SigningProtocol;
            #if MODULAR
            if (this.OriginAccessControlConfig_SigningProtocol == null && ParameterWasBound(nameof(this.OriginAccessControlConfig_SigningProtocol)))
            {
                WriteWarning("You are passing $null as a value for parameter OriginAccessControlConfig_SigningProtocol which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CloudFront.Model.CreateOriginAccessControlRequest();
            
            
             // populate OriginAccessControlConfig
            var requestOriginAccessControlConfigIsNull = true;
            request.OriginAccessControlConfig = new Amazon.CloudFront.Model.OriginAccessControlConfig();
            System.String requestOriginAccessControlConfig_originAccessControlConfig_Description = null;
            if (cmdletContext.OriginAccessControlConfig_Description != null)
            {
                requestOriginAccessControlConfig_originAccessControlConfig_Description = cmdletContext.OriginAccessControlConfig_Description;
            }
            if (requestOriginAccessControlConfig_originAccessControlConfig_Description != null)
            {
                request.OriginAccessControlConfig.Description = requestOriginAccessControlConfig_originAccessControlConfig_Description;
                requestOriginAccessControlConfigIsNull = false;
            }
            System.String requestOriginAccessControlConfig_originAccessControlConfig_Name = null;
            if (cmdletContext.OriginAccessControlConfig_Name != null)
            {
                requestOriginAccessControlConfig_originAccessControlConfig_Name = cmdletContext.OriginAccessControlConfig_Name;
            }
            if (requestOriginAccessControlConfig_originAccessControlConfig_Name != null)
            {
                request.OriginAccessControlConfig.Name = requestOriginAccessControlConfig_originAccessControlConfig_Name;
                requestOriginAccessControlConfigIsNull = false;
            }
            Amazon.CloudFront.OriginAccessControlOriginTypes requestOriginAccessControlConfig_originAccessControlConfig_OriginAccessControlOriginType = null;
            if (cmdletContext.OriginAccessControlConfig_OriginAccessControlOriginType != null)
            {
                requestOriginAccessControlConfig_originAccessControlConfig_OriginAccessControlOriginType = cmdletContext.OriginAccessControlConfig_OriginAccessControlOriginType;
            }
            if (requestOriginAccessControlConfig_originAccessControlConfig_OriginAccessControlOriginType != null)
            {
                request.OriginAccessControlConfig.OriginAccessControlOriginType = requestOriginAccessControlConfig_originAccessControlConfig_OriginAccessControlOriginType;
                requestOriginAccessControlConfigIsNull = false;
            }
            Amazon.CloudFront.OriginAccessControlSigningBehaviors requestOriginAccessControlConfig_originAccessControlConfig_SigningBehavior = null;
            if (cmdletContext.OriginAccessControlConfig_SigningBehavior != null)
            {
                requestOriginAccessControlConfig_originAccessControlConfig_SigningBehavior = cmdletContext.OriginAccessControlConfig_SigningBehavior;
            }
            if (requestOriginAccessControlConfig_originAccessControlConfig_SigningBehavior != null)
            {
                request.OriginAccessControlConfig.SigningBehavior = requestOriginAccessControlConfig_originAccessControlConfig_SigningBehavior;
                requestOriginAccessControlConfigIsNull = false;
            }
            Amazon.CloudFront.OriginAccessControlSigningProtocols requestOriginAccessControlConfig_originAccessControlConfig_SigningProtocol = null;
            if (cmdletContext.OriginAccessControlConfig_SigningProtocol != null)
            {
                requestOriginAccessControlConfig_originAccessControlConfig_SigningProtocol = cmdletContext.OriginAccessControlConfig_SigningProtocol;
            }
            if (requestOriginAccessControlConfig_originAccessControlConfig_SigningProtocol != null)
            {
                request.OriginAccessControlConfig.SigningProtocol = requestOriginAccessControlConfig_originAccessControlConfig_SigningProtocol;
                requestOriginAccessControlConfigIsNull = false;
            }
             // determine if request.OriginAccessControlConfig should be set to null
            if (requestOriginAccessControlConfigIsNull)
            {
                request.OriginAccessControlConfig = null;
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
        
        private Amazon.CloudFront.Model.CreateOriginAccessControlResponse CallAWSServiceOperation(IAmazonCloudFront client, Amazon.CloudFront.Model.CreateOriginAccessControlRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudFront", "CreateOriginAccessControl");
            try
            {
                #if DESKTOP
                return client.CreateOriginAccessControl(request);
                #elif CORECLR
                return client.CreateOriginAccessControlAsync(request).GetAwaiter().GetResult();
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
            public System.String OriginAccessControlConfig_Description { get; set; }
            public System.String OriginAccessControlConfig_Name { get; set; }
            public Amazon.CloudFront.OriginAccessControlOriginTypes OriginAccessControlConfig_OriginAccessControlOriginType { get; set; }
            public Amazon.CloudFront.OriginAccessControlSigningBehaviors OriginAccessControlConfig_SigningBehavior { get; set; }
            public Amazon.CloudFront.OriginAccessControlSigningProtocols OriginAccessControlConfig_SigningProtocol { get; set; }
            public System.Func<Amazon.CloudFront.Model.CreateOriginAccessControlResponse, NewCFOriginAccessControlCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
